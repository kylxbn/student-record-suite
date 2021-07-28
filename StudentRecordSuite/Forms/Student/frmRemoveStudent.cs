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
    public partial class frmRemoveStudent : Form
    {
        bool found = false;

        public frmRemoveStudent(string ID = "")
        {
            InitializeComponent();
            if (ID != "")
            {
                ID = ID.Replace("-", "");
                txtStudentNumber.Text = ID.Substring(ID.Length - 6, 6);
                txtStudentCourse.Text = ID.Substring(0, ID.Length - 6);
            }
        }

        private void txtStudentNumber_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DataTable dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Student_Data WHERE StudentNumber = '{0}' AND StudentCourse = '{1}';", txtStudentNumber.Text, txtStudentCourse.Text));
            if (dt.Rows.Count == 0)
            {
                lblError.Text = UIStrings.L.NOT_FOUND;
                found = false;
                cmdRemove.Enabled = false;
                txtName.Text = "";
            }
            else if (dt.Rows.Count == 1)
            {
                lblError.Text = UIStrings.L.FOUND;
                found = true;
                cmdRemove.Enabled = true;
                txtName.Text = dt.Rows[0]["FName"].ToString() + " " + dt.Rows[0]["LName"].ToString();
            }
            else
            {
                MessageBox.Show(UIStrings.L.MANY_RESULTS, UIStrings.L.MANY_RESULTS_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }

        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            
            if (!found)
            {
                MessageBox.Show(UIStrings.L.DELETE_NONEXISTENT, UIStrings.L.DELETE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkSure.Checked)
            {
                DB.mainDB.Delete("Student_Data", string.Format("StudentNumber = '{0}' AND StudentCourse = '{1}'", txtStudentNumber.Text, txtStudentCourse.Text));
                DB.mainDB.Delete("Student_EnrolledSubjects", string.Format("StudentNumber = '{0}' AND StudentCourse = '{1}'", txtStudentNumber.Text, txtStudentCourse.Text));

                //DB.mainDB.ExecuteNonQuery("DROP TABLE IF EXISTS 
                MessageBox.Show(UIStrings.L.DELETE_OK, UIStrings.L.DELETE_OK_L, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(UIStrings.L.CONFIRM_DELETE, UIStrings.L.CONFIRM_DELETE_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmRemoveStudent_Load(object sender, EventArgs e)
        {
            txtStudentNumber.Focus();
        }


    }
}
