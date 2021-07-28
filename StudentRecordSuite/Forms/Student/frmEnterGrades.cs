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
    public partial class frmEnterGrades : Form
    {
        Dictionary<string, string> subjectNameToCode, subjectCodeToName;

        public frmEnterGrades(string ID = "")
        {
            InitializeComponent();
            string FirstSearch = ID;
            if (FirstSearch.Length > 0)
            {
                txtNumber.Text = FirstSearch.Substring(FirstSearch.Length - 7);
                txtCourse.Text = FirstSearch.Substring(0, FirstSearch.Length - 7);
            }
            subjectNameToCode = new Dictionary<string, string>();
            subjectCodeToName = new Dictionary<string, string>();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                subjectNameToCode[dr["SubjectName"].ToString()] = dr["SubjectCode"].ToString();
                subjectCodeToName[dr["SubjectCode"].ToString()] = dr["SubjectName"].ToString();
            }
        }

        private void txtCourse_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Search();
        }

        private void Search()
        {
            DataTable dt = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Student_Data WHERE StudentCourse = '{0}' AND StudentNumber = '{1}';",
                txtCourse.Text, txtNumber.Text));
            if (dt.Rows.Count == 0)
            {
                lblResult.Text = UIStrings.L.NOT_FOUND;
                lblResult.ForeColor = Color.Red;
                dgvGrades.DataSource = null;
                txtName.Text = "";
                return;
            }

            lblResult.Text = UIStrings.L.FOUND;
            lblResult.ForeColor = Color.Green;
            txtName.Text = String.Format("{0} {1}", dt.Rows[0]["FName"].ToString(), dt.Rows[0]["LName"].ToString());

            DataTable subjects = DB.mainDB.GetDataTable(String.Format("SELECT SubjectCode 'Subject', Date 'Date Enrolled' FROM Student_EnrolledSubjects WHERE StudentCourse = '{0}' AND StudentNumber = '{1}' AND FinalGrade = 'NEW';",
                txtCourse.Text, txtNumber.Text));
            //DataTable date = DB.mainDB.GetDataTable(String.Format("SELECT date FROM Student_EnrolledSubjects WHERE StudentCourse = '{0}' AND StudentNumber = '{1}' AND FinalGrade = 'NEW';", txtCourse.Text, txtNumber.Text));

            dgvGrades.DataSource = subjects;

            if (subjects.Rows.Count == 0) cmdSubmit.Enabled = false; else cmdSubmit.Enabled = true;

            foreach (DataGridViewRow dr in dgvGrades.Rows)
            {
                dr.Cells[1].Value = subjectCodeToName[dr.Cells[1].Value.ToString()];
            }


        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            bool hasFailed = false;
            bool duplicate = false;
            Dictionary<string, string> data;
            Dictionary<string, string> dup = null;
            foreach (DataGridViewRow dr in dgvGrades.Rows)
            {
                data = new Dictionary<string, string>();
                data["FinalGrade"] = dr.Cells[0].Value.ToString();
                if (data["FinalGrade"] == "FAILED" || data["FinalGrade"] == "DROPPED") hasFailed = true;
                if (data["FinalGrade"] == "INCOMPLETE")
                {
                    duplicate = true;
                    dup = new Dictionary<string, string>();
                    dup["StudentNumber"] = txtNumber.Text;
                    dup["StudentCourse"] = txtCourse.Text;
                    dup["SubjectCode"] = subjectNameToCode[dr.Cells[1].Value.ToString()];
                    dup["Date"] = dr.Cells[2].Value.ToString();
                    dup["FinalGrade"] = "NEW";
                }
                DB.mainDB.Update("Student_EnrolledSubjects", data, String.Format("StudentNumber = '{0}' AND StudentCourse = '{1}' AND SubjectCode = '{2}' AND FinalGrade = 'NEW'",
                    txtNumber.Text, txtCourse.Text, subjectNameToCode[dr.Cells[1].Value.ToString()]));
            }

            if (hasFailed)
            {
                Dictionary<string, string> upd = new Dictionary<string, string>();
                upd["Year"] = "0";
                upd["Semester"] = "1";
                DB.mainDB.Update("Student_Data", upd, String.Format("StudentCourse = '{0}' AND StudentNumber = '{1}'", txtCourse.Text, txtNumber.Text));
            }

            if (duplicate)
            {
                DB.mainDB.Insert("Student_EnrolledSubjects", dup);
            }

            // check if student has completed all subjects
            DataTable allSubjects = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Course_Subjects WHERE CourseCode = '{0}';",
                txtCourse.Text));
            DataTable takenSubjects = DB.mainDB.GetDataTable(
                string.Format("SELECT * FROM Student_EnrolledSubjects WHERE StudentNumber = '{0}' AND StudentCourse = '{1}' AND FinalGrade LIKE '_._%';",
                    txtNumber.Text, txtCourse.Text));

            List<string> availableSubjects = new List<string>();
            foreach (DataRow dr in allSubjects.Rows)
            {
                availableSubjects.Add(dr["SubjectCode"].ToString());
            }
            foreach (DataRow dr in takenSubjects.Rows)
            {
                availableSubjects.Remove(dr["Subjectcode"].ToString());
            }

            if (availableSubjects.Count == 0)
            {
                Dictionary<string, string> upd = new Dictionary<string, string>();
                upd["Year"] = "0";
                upd["Semester"] = "2";
                DB.mainDB.Update("Student_Data", upd, String.Format("StudentCourse = '{0}' AND StudentNumber = '{1}'", txtCourse.Text, txtNumber.Text));
                MessageBox.Show(UIStrings.L.STUDENT_GRADUATED, UIStrings.L.CONGRATULATIONS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(UIStrings.L.GRADES_UPDATED, UIStrings.L.UPDATE_OK, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Dispose();
        }

        private void frmEnterGrades_Load(object sender, EventArgs e)
        {
            
        }
    }
}
