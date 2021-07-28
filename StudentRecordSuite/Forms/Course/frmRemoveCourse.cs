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
    public partial class frmRemoveCourse : Form
    {
        Dictionary<string, string> courseNameToCode, courseCodeToName;

        public frmRemoveCourse()
        {
            InitializeComponent();
        }

        private void frmRemoveCourse_Load(object sender, EventArgs e)
        {
            courseNameToCode = new Dictionary<string, string>();
            courseCodeToName = new Dictionary<string, string>();

            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Course_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                courseNameToCode[dr["CourseName"].ToString()] = dr["CourseCode"].ToString();
                courseCodeToName[dr["CourseCode"].ToString()] = dr["CourseName"].ToString();
            }
            foreach (string k in courseNameToCode.Keys)
                cboName.Items.Add(k);
            foreach (string k in courseCodeToName.Keys)
                cboCode.Items.Add(k);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (chkConfirm.Checked)
            {
                if (!cboCode.Items.Contains(cboCode.Text))
                {
                    MessageBox.Show(UIStrings.L.INVALID_COURSE_ABBREVIATION, UIStrings.L.INVALID_COURSE_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DB.mainDB.Delete("Course_Data", string.Format("CourseCode = '{0}'", cboCode.Text));
                DB.mainDB.Delete("Course_Subjects", string.Format("CourseCode = '{0}'", cboCode.Text));
                MessageBox.Show(UIStrings.L.DELETE_OK, UIStrings.L.DELETE_OK_L, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(UIStrings.L.CONFIRM_DELETE, UIStrings.L.CONFIRM_DELETE_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCode.SelectedIndex = cboName.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboName.SelectedIndex = cboCode.SelectedIndex;
        }
    }
}
