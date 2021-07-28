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
    public partial class frmViewEnrolled : Form
    {
        Dictionary<string, string> subjectCodeToName;


        public frmViewEnrolled(string ID = "")
        {
            InitializeComponent();
            if (ID != "")
            {
                ID = ID.Replace("-", "");
                txtSearchStudentNo.Text = ID.Substring(ID.Length - 6, 6);
                txtSearchCourse.Text = ID.Substring(0, ID.Length - 6);
            }
        }

        private void txtSearchStudentNo_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void txtSearchCourse_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            DataTable dt = DB.mainDB.GetDataTable(string.Format("SELECT SubjectCode AS 'Subject Code', FinalGrade AS 'Final Grade', Date AS 'Date Enrolled' FROM Student_EnrolledSubjects WHERE StudentCourse = '{0}' AND StudentNumber = '{1}' AND FinalGrade <> 'NEW' ORDER BY Date ASC;", txtSearchCourse.Text.Trim(), txtSearchStudentNo.Text.Trim()));
            if (dt.Rows.Count == 0)
            {
                lblSearchResult.Text = "No records found";
                dataGridView1.DataSource = null;
                cmdExport.Enabled = false;
                txtName.Text = "";
                txtCourse.Text = "";
                txtYear.Text = "";
                txtSection.Text = "";
                return;
            }
            lblSearchResult.Text = "";
            cmdExport.Enabled = true;
            dataGridView1.DataSource = dt;

            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Student_Data WHERE StudentCourse = '{0}' AND StudentNumber = '{1}';", txtSearchCourse.Text.Trim(), txtSearchStudentNo.Text.Trim()));
            DataRow dr = dt.Rows[0];
            txtName.Text = dr["FName"].ToString() + " " + dr["LName"].ToString();
            txtCourse.Text = dr["StudentCourse"].ToString();
            txtYear.Text = dr["Year"].ToString();
            txtSection.Text = dr["Section"].ToString();

            foreach (DataGridViewRow dr2 in dataGridView1.Rows)
            {
                dr2.Cells[0].Value = subjectCodeToName[dr2.Cells[0].Value.ToString()];
            }
        }

        private void frmViewEnrolled_Load(object sender, EventArgs e)
        {
            subjectCodeToName = new Dictionary<string, string>();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                subjectCodeToName[dr["SubjectCode"].ToString()] = dr["SubjectName"].ToString();
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            DT2HTML.Export(txtName.Text, txtCourse.Text, txtYear.Text, txtSection.Text, (DataTable)dataGridView1.DataSource, @"C:\ProgramData\StudentRecordSuite\temp.html");
            List<string> browsers = new List<string>()
            {
                @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
                @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                @"C:\Program Files\Internet Explorer\iexplore.exe"
            };

            bool found = false;
            foreach (string browser in browsers)
            {
                if (System.IO.File.Exists(browser))
                {
                    System.Diagnostics.Process.Start(browser, @"C:\ProgramData\StudentRecordSuite\temp.html");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("No internet browser found on this device, so report could not be shown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmViewEnrolled_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.IO.File.Exists(@"C:\ProgramData\StudentRecordSuite\temp.html"))
                System.IO.File.Delete(@"C:\ProgramData\StudentRecordSuite\temp.html");
        }

        private void lblSearchResult_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchStudentNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
