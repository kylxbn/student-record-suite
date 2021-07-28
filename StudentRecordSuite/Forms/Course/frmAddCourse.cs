using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace StudentRecordSuite
{
    public partial class frmAddCourse : Form
    {
        int yearIndex, semesterIndex, subjectIndex;
        List<Year> years;
        Dictionary<string, string> subjectNameToCode;

        public frmAddCourse()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAddCourse_Load(object sender, EventArgs e)
        {
            yearIndex = -1;
            semesterIndex = -1;
            subjectIndex = -1;
            years = new List<Year>();
            subjectNameToCode = new Dictionary<string, string>();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                subjectNameToCode.Add(dr["SubjectName"].ToString(), dr["SubjectCode"].ToString());
            }
            foreach (string key in subjectNameToCode.Keys)
            {
                cboSubjects.Items.Add(key);
            }
        }

        private void cmdAddYear_Click(object sender, EventArgs e)
        {
            if (years.Count == 0) yearIndex = 0;
            years.Add(new Year((years.Count + 1).ToString()));
            UpdateYear();
            UpdateButtons();
        }

        private void cmdRemoveYear_Click(object sender, EventArgs e)
        {
            years.RemoveAt(years.Count - 1);
            if (yearIndex >= years.Count)
                yearIndex = years.Count - 1;
            UpdateYear();
            UpdateSemester();
            UpdateSubject();
            UpdateButtons();
        }

        private void UpdateYear()
        {
            lstYear.Items.Clear();
            if (years.Count == 0) return;
            foreach (Year y in years)
            {
                lstYear.Items.Add(y.name);
            }
            if (yearIndex >= lstYear.Items.Count)
                yearIndex = lstYear.Items.Count - 1;
            lstYear.SelectedIndex = yearIndex;
        }

        private void UpdateSemester()
        {
            lstSemester.Items.Clear();
            if (yearIndex >= years.Count)
                return;
            if (yearIndex < 0)
                return;
            foreach (Semester s in years[yearIndex].semesters)
            {
                lstSemester.Items.Add(s.name);
            }
            if (semesterIndex >= lstSemester.Items.Count)
                semesterIndex = lstSemester.Items.Count - 1;
            lstSemester.SelectedIndex = semesterIndex;
        }

        private void UpdateSubject()
        {
            lstSubjects.Items.Clear();
            if (yearIndex >= years.Count)
                return;
            if (yearIndex < 0)
                return;
            if (semesterIndex >= years[yearIndex].semesters.Count)
                return;
            if (semesterIndex < 0)
                return;
            foreach (string s in years[yearIndex].semesters[semesterIndex].subjects)
            {
                lstSubjects.Items.Add(s);
            }
            if (subjectIndex >= lstSubjects.Items.Count)
                subjectIndex = lstSubjects.Items.Count - 1;
            lstSubjects.SelectedIndex = subjectIndex;
        }

        private void lstYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearIndex = lstYear.SelectedIndex;
            UpdateSemester();
            UpdateSubject();
        }

        private void cmdAddSemester_Click(object sender, EventArgs e)
        {
            if (years[yearIndex].semesters.Count == 0) semesterIndex = 0;
            years[yearIndex].semesters.Add(new Semester((years[yearIndex].semesters.Count + 1).ToString()));
            UpdateSemester();
            UpdateButtons();
        }

        private void cmdRemoveSemester_Click(object sender, EventArgs e)
        {
            years[yearIndex].semesters.RemoveAt(years[yearIndex].semesters.Count - 1);
            if (semesterIndex >= years[yearIndex].semesters.Count)
                semesterIndex = years[yearIndex].semesters.Count - 1;
            UpdateSemester();
            UpdateSubject();
            UpdateButtons();
        }

        private void cmdAddSubject_Click(object sender, EventArgs e)
        {
            if (!cboSubjects.Items.Contains(cboSubjects.Text))
            {
                MessageBox.Show(UIStrings.L.INVALID_SUBJECT, UIStrings.L.INVALID_SUBJECT_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Year y in years)
            {
                foreach (Semester s in y.semesters)
                {
                    if (s.subjects.Contains(cboSubjects.Text))
                    {
                        MessageBox.Show(UIStrings.L.SUBJECT_ALREADY_EXISTS, UIStrings.L.INVALID_SUBJECT_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            
            if (years[yearIndex].semesters[semesterIndex].subjects.Count == 0) subjectIndex = 0;
            years[yearIndex].semesters[semesterIndex].subjects.Add(cboSubjects.Text);
            UpdateSubject();
            UpdateButtons();
            cboSubjects.Items.Remove(cboSubjects.Text);
            cboSubjects.Text = "";
        }

        private void lstSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            semesterIndex = lstSemester.SelectedIndex;
            UpdateSubject();
        }

        private void cmdRemoveSubject_Click(object sender, EventArgs e)
        {
            cboSubjects.Items.Add(years[yearIndex].semesters[semesterIndex].subjects[subjectIndex]);
            years[yearIndex].semesters[semesterIndex].subjects.RemoveAt(subjectIndex);
            if (subjectIndex >= years[yearIndex].semesters[semesterIndex].subjects.Count)
                subjectIndex = years[yearIndex].semesters[semesterIndex].subjects.Count - 1;
            UpdateSubject();
            UpdateButtons();
        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            subjectIndex = lstSubjects.SelectedIndex;
        }

        private string TitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        private string TitleCaseAcronym(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show(UIStrings.L.INVALID_COURSE_NAME, UIStrings.L.INVALID_COURSE_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtAbbreviation.Text.Trim() == "")
            {
                MessageBox.Show(UIStrings.L.INVALID_COURSE_ABBREVIATION, UIStrings.L.INVALID_COURSE_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Course_Data WHERE CourseCode = '{0}';", txtAbbreviation.Text));
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(UIStrings.L.COURSE_ALREADY_EXISTS, UIStrings.L.INVALID_COURSE_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (years.Count == 0)
            {
                MessageBox.Show(UIStrings.L.ZERO_YEARS, UIStrings.L.INVALID_COURSE_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Year y in years)
            {
                if (y.semesters.Count == 0)
                {
                    MessageBox.Show(UIStrings.L.ZERO_SEMESTERS, UIStrings.L.INVALID_COURSE_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (Semester s in y.semesters)
                {
                    if (s.subjects.Count == 0)
                    {
                        MessageBox.Show(UIStrings.L.ZERO_SUBJECTS, UIStrings.L.INVALID_COURSE_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("CourseName", txtName.Text);
            data.Add("CourseCode", txtAbbreviation.Text);
            DB.mainDB.Insert("Course_Data", data);
            if (DB.mainDB.error)
            {
                MessageBox.Show(UIStrings.L.INVALID_INPUT, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (Year y in years)
            {
                foreach (Semester s in y.semesters)
                {
                    foreach (string su in s.subjects)
                    {
                        data = new Dictionary<string, string>();
                        data.Add("CourseCode", txtAbbreviation.Text);
                        data.Add("YearName", y.name);
                        data.Add("SemesterName", s.name);
                        data.Add("SubjectCode", subjectNameToCode[su]);
                        DB.mainDB.Insert("Course_Subjects", data);
                    }
                }
            }
            MessageBox.Show(UIStrings.L.ADD_COURSE_OK, UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void UpdateButtons()
        {
            if (lstYear.Items.Count == 0)
            {
                cmdRemoveYear.Enabled = false;
                cmdAddSemester.Enabled = false;
                cmdRemoveSemester.Enabled = false;
                cmdAddSubject.Enabled = false;
                cmdRemoveSubject.Enabled = false;
            }
            else
            {
                cmdRemoveYear.Enabled = true;
                cmdAddSemester.Enabled = true;
                if (lstSemester.Items.Count == 0)
                {
                    cmdRemoveSemester.Enabled = false;
                    cmdAddSubject.Enabled = false;
                    cmdRemoveSubject.Enabled = false;
                }
                else
                {
                    cmdRemoveSemester.Enabled = true;
                    cmdAddSubject.Enabled = true;
                    if (lstSubjects.Items.Count == 0)
                    {
                        cmdRemoveSubject.Enabled = false;
                    }
                    else
                    {
                        cmdRemoveSubject.Enabled = true;
                    }
                }
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            //txtName.Text = TitleCase(txtName.Text);
        }

        private void txtAbbreviation_Leave(object sender, EventArgs e)
        {
            //txtAbbreviation.Text = TitleCaseAcronym(txtAbbreviation.Text);
        }
    }
}
