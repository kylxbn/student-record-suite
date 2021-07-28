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
    public partial class frmEditSubject : Form
    {
        Dictionary<string, string> subjectNameToCode, subjectCodeToName;

        public frmEditSubject()
        {
            InitializeComponent();
        }        

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubjects.SelectedItem == null) return;
            txtName.Text = "";
            txtLaboratory.Text = "";
            txtLecture.Text = "";
            lstPre.Items.Clear();
            lstCo.Items.Clear();
            cboCo.Items.Clear();
            cboPre.Items.Clear();
            foreach (string key in subjectNameToCode.Keys)
            {
                cboPre.Items.Add(key);
                cboCo.Items.Add(key);
            }
            DataTable dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Data WHERE SubjectCode = '{0}';", subjectNameToCode[lstSubjects.SelectedItem.ToString()]));
            if (dt.Rows.Count < 1)
            {
                return;
            }
            LoadPreCo();
            DataRow dr1 = dt.Rows[0];
            txtCode.Text = dr1["SubjectCode"].ToString();
            txtName.Text = dr1["SubjectName"].ToString();
            txtLecture.Text = dr1["LectureUnits"].ToString();
            txtLaboratory.Text = dr1["LaboratoryUnits"].ToString();
            chkAcademic.Checked = dr1["IsAcademic"].ToString() == "1";
            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Prerequisites WHERE SubjectCode = '{0}';", subjectNameToCode[lstSubjects.SelectedItem.ToString()]));
            foreach (DataRow dr in dt.Rows)
            {
                string code = subjectCodeToName[dr["PrerequisiteCode"].ToString()];
                lstPre.Items.Add(code);
                cboPre.Items.Remove(code);
                cboCo.Items.Remove(code);
            }
            dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Subject_Corequisites WHERE SubjectCode = '{0}';", subjectNameToCode[lstSubjects.SelectedItem.ToString()]));
            foreach (DataRow dr in dt.Rows)
            {
                string code = subjectCodeToName[dr["CorequisiteCode"].ToString()];
                lstCo.Items.Add(code);
                cboPre.Items.Remove(code);
                cboCo.Items.Remove(code);
            }
            cmdRemovePre.Enabled = lstPre.Items.Count > 0;
            cmdRemoveCo.Enabled = lstCo.Items.Count > 0;
            cmdSubmit.Enabled = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string code = subjectNameToCode[lstSubjects.SelectedItem.ToString()];
            if (DB.mainDB.GetDataTable(string.Format("SELECT SubjectCode FROM Subject_Data WHERE SubjectCode = '{0}';", code)).Rows.Count == 0)
            {
                MessageBox.Show(UIStrings.L.SUBJECT_NOT_EXIST, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateItems())
                return;

            DB.mainDB.Delete("Subject_Data", string.Format("SubjectCode = '{0}'", code));
            DB.mainDB.Delete("Subject_Prerequisites", string.Format("SubjectCode = '{0}'", code));
            DB.mainDB.Delete("Subject_Corequisites", string.Format("SubjectCode = '{0}'", code));

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

            Dictionary<string, string> updatePre = new Dictionary<string, string>();
            updatePre["PrerequisiteCode"] = txtCode.Text;
            Dictionary<string, string> updateCo = new Dictionary<string, string>();
            updateCo["CorequisiteCode"] = txtCode.Text;
            Dictionary<string, string> updateSubject = new Dictionary<string, string>();
            updateSubject["SubjectCode"] = txtCode.Text;

            DB.mainDB.Update("Subject_Prerequisites", updatePre, string.Format("PrerequisiteCode = '{0}'", subjectNameToCode[lstSubjects.SelectedItem.ToString()]));
            DB.mainDB.Update("Subject_Corequisites", updateCo, string.Format("CorequisiteCode = '{0}'", subjectNameToCode[lstSubjects.SelectedItem.ToString()]));
            DB.mainDB.Update("Course_Subjects", updateSubject, string.Format("SubjectCode = '{0}'", subjectNameToCode[lstSubjects.SelectedItem.ToString()]));
            DB.mainDB.Update("Student_EnrolledSubjects", updateSubject, string.Format("SubjectCode = '{0}'", subjectNameToCode[lstSubjects.SelectedItem.ToString()]));

            MessageBox.Show(UIStrings.L.SUBJECT_EDITED, UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Dispose();
        }

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

        private void LoadPreCo()
        {
            cboPre.Items.Clear();
            cboCo.Items.Clear();
            string l = lstSubjects.SelectedItem.ToString();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (string key in subjectNameToCode.Keys)
            {
                if (key != l)
                {
                    cboPre.Items.Add(key);
                    cboCo.Items.Add(key);
                }
            }
        }

        private void frmEditSubject_Load(object sender, EventArgs e)
        {
            LoadDicts();
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                lstSubjects.Items.Add(dr["SubjectName"].ToString());
            }
        }

        private void txtLaboratory_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


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
    }
}
