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
    public partial class frmDeleteSubject : Form
    {
        Dictionary<string, string> subjectNameToCode, subjectCodeToName;

        private void LoadDicts()
        {
            subjectNameToCode = new Dictionary<string, string>();
            subjectCodeToName = new Dictionary<string, string>();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                subjectNameToCode[dr["SubjectName"].ToString()] = dr["SubjectCode"].ToString();
                subjectCodeToName[dr["SubjectCode"].ToString()] = dr["SubjectName"].ToString();
            }
        }

        private void UpdateAffected()
        {
            lstPre.Items.Clear();
            lstCo.Items.Clear();
            lstCourses.Items.Clear();
            DataTable dt;
            string code = cboCode.Text;
            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Prerequisites WHERE PrerequisiteCode = '{0}';", code));
            foreach (DataRow dr in dt.Rows)
            {
                lstPre.Items.Add(subjectCodeToName[dr["SubjectCode"].ToString()]);
            }
            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Corequisites WHERE CorequisiteCode = '{0}';", code));
            foreach (DataRow dr in dt.Rows)
            {
                lstCo.Items.Add(subjectCodeToName[dr["SubjectCode"].ToString()]);
            }
            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Course_Subjects WHERE SubjectCode = '{0}';", code));
            foreach (DataRow dr in dt.Rows)
            {
                lstCourses.Items.Add(
                    string.Format("{0} Year {1} Semester {2}",
                    dr["CourseCode"].ToString(),
                    dr["YearName"].ToString(),
                    dr["SemesterName"].ToString()
                    ));
            }
        }

        public frmDeleteSubject()
        {
            InitializeComponent();
        }

        private void cboCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboName.SelectedIndex = cboCode.SelectedIndex;
            UpdateAffected();
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCode.SelectedIndex = cboName.SelectedIndex;
            UpdateAffected();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code = cboCode.Text;

            DataTable dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Data WHERE SubjectCode = '{0}';", code));
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show(UIStrings.L.DELETE_NONEXISTENT, UIStrings.L.DELETE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkConfirm.Checked)
            {
                string f1 = string.Format("SubjectCode = '{0}'", code);
                string f2 = string.Format("PrerequisiteCode = '{0}' OR SubjectCode = '{0}'", code);
                string f3 = string.Format("CorequisiteCode = '{0}' OR SubjectCode = '{0}'", code);

                DB.mainDB.Delete("Subject_Data", f1);
                DB.mainDB.Delete("Subject_Prerequisites", f2);
                DB.mainDB.Delete("Subject_Corequisites", f3);
                DB.mainDB.Delete("Course_Subjects", f1);
                MessageBox.Show(UIStrings.L.DELETE_OK, UIStrings.L.DELETE_OK_L, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(UIStrings.L.CONFIRM_DELETE, UIStrings.L.CONFIRM_DELETE_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmDeleteSubject_Load(object sender, EventArgs e)
        {
            LoadDicts();
            foreach (string k in subjectNameToCode.Keys)
                cboName.Items.Add(k);
            foreach (string k in subjectCodeToName.Keys)
                cboCode.Items.Add(k);
        }
    }
}
