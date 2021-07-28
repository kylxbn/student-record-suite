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
    public partial class frmAddSubject : Form
    {
        Dictionary<string, string> subjectNameToCode;

        public frmAddSubject()
        {
            InitializeComponent();
        }

        private void frmAddSubject_Load(object sender, EventArgs e)
        {
            subjectNameToCode = new Dictionary<string, string>();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                subjectNameToCode[dr["SubjectName"].ToString()] = dr["SubjectCode"].ToString();
            }
            foreach (string key in subjectNameToCode.Keys)
            {
                cboCo.Items.Add(key);
                cboPre.Items.Add(key);
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (DB.mainDB.GetDataTable(string.Format("SELECT SubjectCode FROM Subject_Data WHERE SubjectCode = '{0}';", txtCode.Text)).Rows.Count > 0) {
                MessageBox.Show(UIStrings.L.SUBJECT_EXISTS, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            
            if (!ValidateItems())
                return;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("SubjectCode", txtCode.Text);
            data.Add("SubjectName", txtName.Text);
            data.Add("LectureUnits", txtLecture.Text);
            data.Add("LaboratoryUnits", txtLaboratory.Text);
            if (chkAcademic.Checked)
                data.Add("IsAcademic", "1");
            else
                data.Add("IsAcademic", "0");

            DB.mainDB.Insert("Subject_Data", data);
            if (DB.mainDB.error)
            {
                MessageBox.Show(UIStrings.L.INVALID_INPUT, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach (object i in lstPre.Items)
            {
                data = new Dictionary<string, string>();
                data.Add("SubjectCode", txtCode.Text);
                data.Add("PrerequisiteCode", subjectNameToCode[i.ToString()]);
                DB.mainDB.Insert("Subject_Prerequisites", data);
            }

            foreach (object i in lstCo.Items)
            {
                data = new Dictionary<string, string>();
                data.Add("SubjectCode", txtCode.Text);
                data.Add("CorequisiteCode", subjectNameToCode[i.ToString()]);
                DB.mainDB.Insert("Subject_Corequisites", data);
            }
            
            MessageBox.Show(UIStrings.L.SUBJECT_ADDED, UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (chkClose.Checked)
                this.Dispose();
            else
            {
                txtCode.Text = "";
                txtName.Text = "";
                txtLaboratory.Text = "";
                txtLecture.Text = "";
                chkAcademic.Checked = true;
                lstPre.Items.Clear();
                lstCo.Items.Clear();
                cboPre.Items.Clear();
                cboCo.Items.Clear();
                cmdRemoveCo.Enabled = false;
                cmdRemovePre.Enabled = false;
                frmAddSubject_Load(null, null);
            }
        }

        private bool ValidateItems()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show(UIStrings.L.MISSING_SUBJECT_NAME, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCode.Text == "")
            {
                MessageBox.Show(UIStrings.L.MISSING_SUBJECT_CODE, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtLecture.Text == "") txtLecture.Text = "0";
            if (txtLaboratory.Text == "") txtLaboratory.Text = "0";
            if (txtLecture.Text == "0" && txtLaboratory.Text == "0")
            {
                MessageBox.Show(UIStrings.L.ZERO_UNITS, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdAddPre_Click(object sender, EventArgs e)
        {
            if (!cboPre.Items.Contains(cboPre.Text))
            {
                MessageBox.Show(UIStrings.L.INVALID_SUBJECT, UIStrings.L.INVALID_SUBJECT_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            lstPre.Items.Add(cboPre.Text);
            cmdRemovePre.Enabled = true;
            string r = cboPre.Text;
            cboCo.Items.Remove(r);
            cboPre.Items.Remove(r);
            cboPre.Text = "";
        }

        private void cmdRemovePre_Click(object sender, EventArgs e)
        {
            if (lstPre.SelectedIndex == -1)
            {
                MessageBox.Show(UIStrings.L.SELECT_ITEM_FIRST, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            cboPre.Items.Add(lstPre.Items[lstPre.SelectedIndex]);
            cboCo.Items.Add(lstPre.Items[lstPre.SelectedIndex]);
            lstPre.Items.RemoveAt(lstPre.SelectedIndex);
            if (lstPre.Items.Count == 0)
                cmdRemovePre.Enabled = false;
        }

        private void cmdAddCo_Click(object sender, EventArgs e)
        {
            if (!cboCo.Items.Contains(cboCo.Text))
            {
                MessageBox.Show(UIStrings.L.INVALID_SUBJECT, UIStrings.L.INVALID_SUBJECT_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            lstCo.Items.Add(cboCo.Text);
            cmdRemoveCo.Enabled = true;
            string r = cboCo.Text;
            cboCo.Items.Remove(r);
            cboPre.Items.Remove(r);
            cboCo.Text = "";
        }

        private void cmdRemoveCo_Click(object sender, EventArgs e)
        {
            if (lstCo.SelectedIndex == -1)
            {
                MessageBox.Show(UIStrings.L.SELECT_ITEM_FIRST, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            cboPre.Items.Add(lstCo.Items[lstCo.SelectedIndex]);
            cboCo.Items.Add(lstCo.Items[lstCo.SelectedIndex]);
            lstCo.Items.RemoveAt(lstCo.SelectedIndex);
            if (lstCo.Items.Count == 0)
                cmdRemoveCo.Enabled = false;
        }

    }
}
