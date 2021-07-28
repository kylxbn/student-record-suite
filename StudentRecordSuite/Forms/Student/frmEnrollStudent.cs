using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentRecordSuite
{
    public partial class frmEnrollStudent : Form
    {
        string FirstSearch;
        Dictionary<string, string> subjectCodeToName, subjectNameToCode;
        DataTable allSubjects, takenSubjects, pendingSubjects;
        int resultingYear;
        int resultingSemester;
        bool silent = false;

        public frmEnrollStudent(string ID = "")
        {
            InitializeComponent();
            FirstSearch = ID;
            if (FirstSearch.Length > 0)
            {
                txtNumber.Text = FirstSearch.Substring(FirstSearch.Length - 7);
                txtCourse.Text = FirstSearch.Substring(0, FirstSearch.Length - 7);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmEnrollStudent_Load(object sender, EventArgs e)
        {
            subjectNameToCode = new Dictionary<string, string>();
            subjectCodeToName = new Dictionary<string, string>();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                subjectNameToCode[dr["SubjectName"].ToString()] = dr["SubjectCode"].ToString();
                subjectCodeToName[dr["SubjectCode"].ToString()] = dr["SubjectName"].ToString();
            }
            
            txtUnits.Text = "0";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Search();
            timer.Stop();
        }

        private void Search()
        {
            if (!timer.Enabled) return;
            DataTable dt = DB.mainDB.GetDataTable(
                string.Format("SELECT FName, LName FROM Student_Data WHERE StudentCourse = '{0}' AND StudentNumber = '{1}';",
                                txtCourse.Text, txtNumber.Text));

            if (dt.Rows.Count == 0)
            {
                lblResult.Text = UIStrings.L.NOT_FOUND;
                lblResult.ForeColor = Color.Red;
                txtName.Text = "";
                lblRegular.Visible = false;
                lblBecome.Visible = false;
                lstAvailable.Items.Clear();
                lstEnrolled.Items.Clear();
                return;
            }

            lblResult.Text = UIStrings.L.FOUND;
            lblResult.ForeColor = Color.Green;
            txtName.Text = string.Format("{0} {1}", dt.Rows[0]["FName"].ToString(), dt.Rows[0]["LName"]);
            lblRegular.Visible = true;
            lblBecome.Visible = true;
            dt = DB.mainDB.GetDataTable(String.Format("SELECT Year, Semester FROM Student_Data WHERE StudentCourse = '{0}' AND StudentNumber = '{1}';",
                txtCourse.Text, txtNumber.Text));
            int year = Convert.ToInt32(dt.Rows[0]["Year"]);
            int semester = Convert.ToInt32(dt.Rows[0]["Semester"]);
            bool regular;
            if (year == 0 && semester == 1) regular = false; else regular = true;
            if (regular)
            {
                if (year + semester == 0)
                    lblRegular.Text = UIStrings.L.NEW_STUDENT;
                else
                    lblRegular.Text = String.Format(UIStrings.L.REGULAR_STUDENT, year, semester);
            }
            else
            {
                lblRegular.Text = UIStrings.L.IRREGULAR_STUDENT;
                chkAllowIrregular.Checked = true;
            }

            lstAvailable.Items.Clear();
            lstEnrolled.Items.Clear();
            txtUnits.Text = "0";
            txtUnits.ForeColor = Color.LimeGreen;
            dt.Dispose();

            allSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Course_Subjects WHERE CourseCode = '{0}';",
                txtCourse.Text));
            takenSubjects = DB.mainDB.GetDataTable(
                string.Format("SELECT * FROM Student_EnrolledSubjects WHERE StudentNumber = '{0}' AND StudentCourse = '{1}' AND FinalGrade LIKE '_.%';",
                    txtNumber.Text, txtCourse.Text));
            pendingSubjects = DB.mainDB.GetDataTable(
                string.Format("SELECT * FROM Student_EnrolledSubjects WHERE StudentNumber = '{0}' AND StudentCourse = '{1}' AND (FinalGrade = 'NEW' OR FinalGrade = 'INCOMPLETE');",
                    txtNumber.Text, txtCourse.Text));
            foreach (DataRow dr in allSubjects.Rows)
            {
                lstAvailable.Items.Add(subjectCodeToName[dr["SubjectCode"].ToString()]);
            }
            foreach (DataRow dr in takenSubjects.Rows)
            {
                lstAvailable.Items.Remove(subjectCodeToName[dr["Subjectcode"].ToString()]);
            }
            foreach (DataRow dr in pendingSubjects.Rows)
            {
                lstAvailable.Items.Remove(subjectCodeToName[dr["Subjectcode"].ToString()]);
            }

            UpdateNewLevel();

            if (lblRegular.Text == "Regular Y0S2" && lblBecome.Text == "Regular Y0S2" && lstAvailable.Items.Count == 0)
            {
                lblRegular.Text = "Graduated";
                lblBecome.Text = "Graduated";
            }
        }

        private void txtCourse_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void txtSubjectSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstEnrolled.SelectedIndex < 0)
            {
                MessageBox.Show(UIStrings.L.SELECT_ITEM_FIRST, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string toRemove = subjectNameToCode[lstEnrolled.SelectedItem.ToString()];
            DataTable dt;
            string code;
            string depends = "";
            List<String> depend = new List<String>();
            foreach (string s in lstEnrolled.Items)
            {
                code = subjectNameToCode[s];
                if (code != toRemove)
                {
                    dt = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Subject_Prerequisites WHERE SubjectCode = '{0}' AND PrerequisiteCode = '{1}';",
                        code, toRemove));
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!depend.Contains(dr["SubjectCode"].ToString())) depend.Add(dr["SubjectCode"].ToString());
                    }
                    dt = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Subject_Corequisites WHERE SubjectCode = '{0}' AND CorequisiteCode = '{1}';",
                        code, toRemove));
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!depend.Contains(dr["SubjectCode"].ToString())) depend.Add(dr["SubjectCode"].ToString());
                    }
                }
            }
            if (depend.Count > 0)
            {
                foreach (string s in depend)
                {
                    depends += subjectCodeToName[s] + "\n";
                }
                MessageBox.Show(UIStrings.L.CANT_DELETE_DEPENDENCY_SUBJECT + depends, UIStrings.L.DELETE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            lstAvailable.Items.Add(lstEnrolled.SelectedItem);
            lstEnrolled.Items.RemoveAt(lstEnrolled.SelectedIndex);

            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Data WHERE SubjectCode = '{0}';", toRemove));
            DataRow units = dt.Rows[0];
            int currentUnits = Convert.ToInt32(txtUnits.Text);
            currentUnits -= Convert.ToInt32(units["LectureUnits"]) + Convert.ToInt32(units["LaboratoryUnits"]);
            txtUnits.Text = currentUnits.ToString();
            if (currentUnits <= ProgramConfig.nongradUnits)
                txtUnits.ForeColor = Color.LimeGreen;
            else if (currentUnits > ProgramConfig.nongradUnits && currentUnits <= ProgramConfig.gradUnits)
                txtUnits.ForeColor = Color.Orange;
            else
                txtUnits.ForeColor = Color.Red;

            UpdateNewLevel();
        }



        private void cmdAddAll_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "Not found") return;

            DataTable pending = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Student_EnrolledSubjects WHERE StudentCourse = '{0}' AND StudentNumber = '{1}' AND FinalGrade = 'NEW';", txtCourse.Text, txtNumber.Text));
            if (pending.Rows.Count > 0 && !chkForceEnroll.Checked)
            {
                MessageBox.Show(UIStrings.L.PENDING_SUBJECTS, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (lblRegular.Text == "Graduated")
            {
                MessageBox.Show("Student has already graduated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (lblResult.Text == "Not found")
            {
                MessageBox.Show(UIStrings.L.SELECT_STUDENT_FIRST, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cmdRemoveAll_Click(null, null);
            DataTable dt = DB.mainDB.GetDataTable(String.Format("SELECT Year, Semester FROM Student_Data WHERE StudentCourse = '{0}' AND StudentNumber = '{1}';",
                txtCourse.Text, txtNumber.Text));
            int year = Convert.ToInt32(dt.Rows[0]["Year"]);
            int semester = Convert.ToInt32(dt.Rows[0]["Semester"]);
            bool regular;
            if (year == 0 && semester == 1) regular = false; else regular = true;
            
            // in case the student is newly enrolled,
            // let's give him/her the first year/first semester's subjects.
            if (year==0 && semester==0)
            {
                DataTable nextSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Course_Subjects WHERE CourseCode = '{0}' AND YearName = '1' AND SemesterName = '1';",
                    txtCourse.Text));
                string toAdd;
                foreach (DataRow dr in nextSubjects.Rows)
                {
                    toAdd = subjectCodeToName[dr["SubjectCode"].ToString()];
                    lstAvailable.Items.Remove(toAdd);
                    lstEnrolled.Items.Add(toAdd);
                    dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Data WHERE SubjectCode = '{0}';", subjectNameToCode[toAdd]));
                    DataRow units = dt.Rows[0];
                    int currentUnits = Convert.ToInt32(txtUnits.Text);
                    currentUnits += Convert.ToInt32(units["LectureUnits"]) + Convert.ToInt32(units["LaboratoryUnits"]);
                    txtUnits.Text = currentUnits.ToString();
                    if (currentUnits <= ProgramConfig.nongradUnits)
                        txtUnits.ForeColor = Color.LimeGreen;
                    else if (currentUnits > ProgramConfig.nongradUnits && currentUnits <= ProgramConfig.gradUnits)
                        txtUnits.ForeColor = Color.Orange;
                    else
                        txtUnits.ForeColor = Color.Red;
                }
                resultingSemester = 1;
                resultingYear = 1;
                UpdateNewLevel();
                return;
            }

            // in case the student is a regular student
            // let's give him/her the next year/semester's subjects
            if (regular)
            {
                semester++;
                DataTable nextSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * From Course_Subjects WHERE CourseCode = '{0}' AND YearName = '{1}' AND SemesterName = '{2}';",
                    txtCourse.Text, year, semester));
                if (nextSubjects.Rows.Count == 0)
                {
                    // this means that there is no such semester for that year, so 
                    // we reset the semester to 1, then increment the year.
                    semester = 1;
                    year++;
                    // then we get the subject list again.
                    nextSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * From Course_Subjects WHERE CourseCode = '{0}' AND YearName = '{1}' AND SemesterName = '{2}';",
                        txtCourse.Text, year, semester));
                    if (nextSubjects.Rows.Count == 0)
                    {
                        // this means that--the student has already finished all subjects--regularly!
                        // OMEDETOU GOZAIMASU! JAA, O-KANE O KUDASAI!!!!!!!
                        MessageBox.Show(UIStrings.L.NO_MORE_SUBJECTS, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateNewLevel();
                        return;
                    }
                }
                // at this point, we have a list of subjects for the next sem/year.
                string toAdd;
                foreach (DataRow dr in nextSubjects.Rows)
                {
                    toAdd = subjectCodeToName[dr["SubjectCode"].ToString()];
                    lstAvailable.Items.Remove(toAdd);
                    lstEnrolled.Items.Add(toAdd);
                    dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Data WHERE SubjectCode = '{0}';", subjectNameToCode[toAdd]));
                    DataRow units = dt.Rows[0];
                    int currentUnits = Convert.ToInt32(txtUnits.Text);
                    currentUnits += Convert.ToInt32(units["LectureUnits"]) + Convert.ToInt32(units["LaboratoryUnits"]);
                    txtUnits.Text = currentUnits.ToString();
                    if (currentUnits <= ProgramConfig.nongradUnits)
                        txtUnits.ForeColor = Color.LimeGreen;
                    else if (currentUnits > ProgramConfig.nongradUnits && currentUnits <= ProgramConfig.gradUnits)
                        txtUnits.ForeColor = Color.Orange;
                    else
                        txtUnits.ForeColor = Color.Red;
                }
                resultingSemester = semester;
                resultingYear = year;
                UpdateNewLevel();
                return;
            }

            // in case the student is irregular, let's give him/her subjects (of course, following the rules)
            // until he/she can't take any more.
            if (!regular)
            {
                int index = 0;
                string prevUnits;
                silent = true;
                while (Convert.ToInt32(txtUnits.Text) <= ProgramConfig.gradUnits && index < lstAvailable.Items.Count)
                {
                    prevUnits = txtUnits.Text;
                    lstAvailable.SelectedIndex = index;
                    cmdAdd_Click(null, null);
                    if (prevUnits == txtUnits.Text) index++;
                }
                silent = false;
                if (Convert.ToInt32(txtUnits.Text) > ProgramConfig.nongradUnits)
                {
                    // the auto-add added too much subjects than normal--
                    // but if he/she is graduating, and it is less than the graduating limit, let's allow it.
                    if (Convert.ToInt32(txtUnits.Text) <= ProgramConfig.gradUnits && lstAvailable.Items.Count == 0)
                    {
                        UpdateNewLevel();
                        return;
                    }
                    // but if he/she's not graduating
                    else
                    {
                        // let's remove subjects one by one until it fits.
                        while (Convert.ToInt32(txtUnits.Text) > ProgramConfig.nongradUnits && lstEnrolled.Items.Count > 0)
                        {
                            lstEnrolled.SelectedIndex = lstEnrolled.Items.Count - 1;
                            cmdRemove_Click(null, null);
                        }
                        UpdateNewLevel();
                        return;
                    }
                }
            }
            
        }

        private void cmdRemoveAll_Click(object sender, EventArgs e)
        {
            List<String> rem = new List<String>();
            foreach (string s in lstEnrolled.Items)
            {
                rem.Add(s);
            }
            foreach (string s in rem)
            {
                lstAvailable.Items.Add(s);
                lstEnrolled.Items.Remove(s);
            }
            txtUnits.Text = "0";
            txtUnits.ForeColor = Color.LimeGreen;

            UpdateNewLevel();
        }

        private void UpdateNewLevel()
        {
            if (lstEnrolled.Items.Count == 0)
            {
                lblBecome.ForeColor = SystemColors.ControlText;
                lblBecome.Text = lblRegular.Text;
                return;
            }
            bool i = WillBecomeIrregular();
            if (i)
            {
                lblBecome.ForeColor = Color.Red;
                lblBecome.Text = UIStrings.L.IRREGULAR_STUDENT;
            }
            else
            {
                lblBecome.ForeColor = Color.LimeGreen;
                lblBecome.Text = String.Format(UIStrings.L.REGULAR_STUDENT, resultingYear, resultingSemester);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == UIStrings.L.NOT_FOUND)
            {
                MessageBox.Show(UIStrings.L.SELECT_STUDENT_FIRST, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DataTable pending = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Student_EnrolledSubjects WHERE StudentCourse = '{0}' AND StudentNumber = '{1}' AND FinalGrade = 'NEW';", txtCourse.Text, txtNumber.Text));
            if (pending.Rows.Count > 0 && !chkForceEnroll.Checked)
            {
                MessageBox.Show(UIStrings.L.PENDING_SUBJECTS, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (lstEnrolled.Items.Count == 0)
            {
                MessageBox.Show(UIStrings.L.ADD_SUBJECTS_FIRST, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (Convert.ToInt32(txtUnits.Text) > ProgramConfig.gradUnits && !chkForceEnroll.Checked)
            {
                MessageBox.Show(UIStrings.L.EXCEED_GRADUNITS, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (Convert.ToInt32(txtUnits.Text) > ProgramConfig.nongradUnits && lstAvailable.Items.Count > 0 && !chkForceEnroll.Checked)
            {
                MessageBox.Show(UIStrings.L.EXCEED_NONGRADUNITS, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            if (lblRegular.Text != UIStrings.L.IRREGULAR_STUDENT)
            {
                if (WillBecomeIrregular() && !chkAllowIrregular.Checked)
                {
                    MessageBox.Show(UIStrings.L.WILL_BECOME_IRREGULAR, UIStrings.L.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            Dictionary<string, string> data;
            foreach (string s in lstEnrolled.Items)
            {
                data = new Dictionary<string, string>();
                data["StudentNumber"] = txtNumber.Text;
                data["StudentCourse"] = txtCourse.Text;
                data["SubjectCode"] = subjectNameToCode[s];
                data["FinalGrade"] = "NEW";
                dtpDate.Format = DateTimePickerFormat.Custom;
                data["Date"] = dtpDate.Text;
                dtpDate.Format = DateTimePickerFormat.Long;
                DB.mainDB.Insert("Student_EnrolledSubjects", data);
            }

            data = new Dictionary<string, string>();
            data["Semester"] = String.Format("{0}", resultingSemester);
            data["Year"] = String.Format("{0}", resultingYear);
            DB.mainDB.Update("Student_Data", data, String.Format("StudentCourse = '{0}' AND StudentNumber = '{1}'", txtCourse.Text, txtNumber.Text));

            MessageBox.Show(UIStrings.L.SUBJECTS_ENROLLED, UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool WillBecomeIrregular()
        {
            DataTable dt = DB.mainDB.GetDataTable(String.Format("SELECT Year, Semester FROM Student_Data WHERE StudentCourse = '{0}' AND StudentNumber = '{1}';",
                txtCourse.Text, txtNumber.Text));
            int year = Convert.ToInt32(dt.Rows[0]["Year"]);
            int semester = Convert.ToInt32(dt.Rows[0]["Semester"]);
            bool regular;
            if (year == 0 && semester == 1) regular = false; else regular = true;
            if (!regular) return true;

            // in case the student is newly enrolled,
            // let's give him/her the first year/first semester's subjects.
            if (year == 0 && semester == 0)
            {
                DataTable nextSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Course_Subjects WHERE CourseCode = '{0}' AND YearName = '1' AND SemesterName = '1';",
                    txtCourse.Text));
                string toAdd;
                foreach (DataRow dr in nextSubjects.Rows)
                {
                    Dictionary<String, bool> selected = new Dictionary<String, bool>();
                    foreach (DataRow dr2 in nextSubjects.Rows)
                    {
                        toAdd = subjectCodeToName[dr2["SubjectCode"].ToString()];
                        selected[toAdd] = false;
                    }
                    foreach (string s in lstEnrolled.Items)
                    {
                        selected[s] = true;
                    }
                    bool remainRegular = true;
                    foreach (string k in selected.Keys)
                    {
                        if (remainRegular)
                            remainRegular = selected[k];
                    }
                    if (remainRegular)
                    {
                        resultingYear = 1;
                        resultingSemester = 1;
                    }
                    else
                    {
                        resultingYear = 0;
                        resultingSemester = 1;
                    }
                    if (nextSubjects.Rows.Count != lstEnrolled.Items.Count)
                        return true;
                    return !remainRegular;
                }
            }

            if (regular)
            {
                semester++;
                DataTable nextSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * From Course_Subjects WHERE CourseCode = '{0}' AND YearName = '{1}' AND SemesterName = '{2}';",
                    txtCourse.Text, year, semester));
                if (nextSubjects.Rows.Count == 0)
                {
                    // this means that there is no such semester for that year, so 
                    // we reset the semester to 1, then increment the year.
                    semester = 1;
                    year++;
                    // then we get the subject list again.
                    nextSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * From Course_Subjects WHERE CourseCode = '{0}' AND YearName = '{1}' AND SemesterName = '{2}';",
                        txtCourse.Text, year, semester));
                    if (nextSubjects.Rows.Count == 0)
                    {
                        // this means that--the student has already finished all subjects--regularly!
                        // OMEDETOU GOZAIMASU! JAA, O-KANE O KUDASAI!!!!!!!
                        return false;
                    }
                }
                // at this point, we have a list of subjects for the next sem/year.
                string toAdd;
                if (nextSubjects.Rows.Count != lstEnrolled.Items.Count)
                    return true;
                Dictionary<String, bool> selected = new Dictionary<String, bool>();
                foreach (DataRow dr in nextSubjects.Rows)
                {
                    toAdd = subjectCodeToName[dr["SubjectCode"].ToString()];
                    selected[toAdd] = false;
                }
                foreach (string s in lstEnrolled.Items)
                {
                    selected[s] = true;
                }
                bool remainRegular = true;
                foreach (string k in selected.Keys)
                {
                    if (remainRegular)
                        remainRegular = selected[k];
                }
                if (remainRegular)
                {
                    resultingYear = year;
                    resultingSemester = semester;
                }
                return !remainRegular;
            }
            return false;
        }

        private void chkAllowIrregular_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedIndex < 0)
            {
                if (!silent) MessageBox.Show(UIStrings.L.SELECT_ITEM_FIRST, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string toAdd = subjectNameToCode[lstAvailable.SelectedItem.ToString()];

            DataTable dt;

            // *requisites
            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Corequisites WHERE SubjectCode = '{0}';", toAdd));
            Dictionary<string, bool> corequisiteSatisfied = new Dictionary<string, bool>();
            foreach (DataRow dr in dt.Rows)
            {
                corequisiteSatisfied[dr["CorequisiteCode"].ToString()] = false;
            }
            List<String> coKeys = new List<String>();
            foreach (string k in corequisiteSatisfied.Keys)
            {
                coKeys.Add(k);
            }
            foreach (string s in coKeys)
            {
                corequisiteSatisfied[s] = lstEnrolled.Items.Contains(subjectCodeToName[s]);
            }
            string error = "";
            foreach (string s in corequisiteSatisfied.Keys)
            {
                if (corequisiteSatisfied[s] == false)
                    error += subjectCodeToName[s] + "\n";
            }
            if (error.Length > 0 && !chkIgnoreRequisite.Checked)
            {
                if (!silent) MessageBox.Show(UIStrings.L.COREQUISITE + "\n\n" + error, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //---------------------
            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Prerequisites WHERE SubjectCode = '{0}';", toAdd));
            Dictionary<string, bool> prerequisiteSatisfied = new Dictionary<string, bool>();
            foreach (DataRow dr in dt.Rows)
            {
                prerequisiteSatisfied[dr["PrerequisiteCode"].ToString()] = false;
            }
            List<String> preKeys = new List<String>();
            foreach (string k in prerequisiteSatisfied.Keys)
            {
                preKeys.Add(k);
            }
            foreach (string s in preKeys)
            {
                dt = DB.mainDB.GetDataTable(
                    String.Format("SELECT * FROM Student_EnrolledSubjects WHERE StudentNumber = '{0}' AND StudentCourse = '{1}' AND SubjectCode = '{2}' AND FinalGrade LIKE '_.%';",
                        txtNumber.Text, txtCourse.Text, s));
                prerequisiteSatisfied[s] = dt.Rows.Count > 0;
            }
            error = "";
            foreach (string s in prerequisiteSatisfied.Keys)
            {
                if (prerequisiteSatisfied[s] == false)
                    error += subjectCodeToName[s] + "\n";
            }
            if (error.Length > 0 && !chkIgnoreRequisite.Checked)
            {
                if (!silent) MessageBox.Show(UIStrings.L.PREREQUISITE + "\n\n" + error, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Yay! Requisites are all satisfied! jugyou o tsuika shiyou na!
            // ...or the 'Ignore Requisites' option is checked :/
            lstAvailable.Items.Remove(subjectCodeToName[toAdd]);
            lstEnrolled.Items.Add(subjectCodeToName[toAdd]);

            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Data WHERE SubjectCode = '{0}';", toAdd));
            DataRow units = dt.Rows[0];
            int currentUnits = Convert.ToInt32(txtUnits.Text);
            currentUnits += Convert.ToInt32(units["LectureUnits"]) + Convert.ToInt32(units["LaboratoryUnits"]);
            txtUnits.Text = currentUnits.ToString();
            if (currentUnits <= ProgramConfig.nongradUnits)
                txtUnits.ForeColor = Color.LimeGreen;
            else if (currentUnits > ProgramConfig.nongradUnits && currentUnits <= ProgramConfig.gradUnits)
                txtUnits.ForeColor = Color.Orange;
            else
                txtUnits.ForeColor = Color.Red;

            UpdateNewLevel();
        }

        private void txtNumber_MaskInputRejected(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
