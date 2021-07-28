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
    public partial class frmImportGrades : Form
    {
        ExcelReader reader = new ExcelReader();
        Dictionary<String, String> subjectNameToCode;

        public frmImportGrades()
        {
            InitializeComponent();
        }

        private void frmImportGrades_Load(object sender, EventArgs e)
        {
            DataTable dt = DB.mainDB.GetDataTable("SELECT * FROM Subject_Data;");
            subjectNameToCode = new Dictionary<String, String>();
            foreach (DataRow dr in dt.Rows)
            {
                cboSubjects.Items.Add(dr["SubjectName"].ToString());
                subjectNameToCode[dr["SubjectName"].ToString()] = dr["SubjectCode"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openDlg.ShowDialog();
            txtPath.Text = openDlg.FileName;
            
        }

        private void txtLoad_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim().Length == 0)
            {
                MessageBox.Show(UIStrings.L.SELECT_FILE_FIRST, UIStrings.L.LOAD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSheet.Text.Trim().Length == 0)
            {
                MessageBox.Show(UIStrings.L.TYPE_SHEET_NAME, UIStrings.L.LOAD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sheetNameWithRange = txtSheet.Text + "$"; // Read excel sheet document from A1 cell to D10 cell values.
                DataTable sheetTableWithRange = reader.loadSingleSheet(txtPath.Text, sheetNameWithRange);
                dgv.DataSource = sheetTableWithRange;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, UIStrings.L.LOAD_ERROR);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNameCellX.Text = dgv.CurrentCellAddress.X.ToString();
            txtNameCellY.Text = dgv.CurrentCellAddress.Y.ToString();
        }

        private void cmdGradeCurrent_Click(object sender, EventArgs e)
        {
            txtGradeCellX.Text = dgv.CurrentCellAddress.X.ToString();
            txtGradeCellY.Text = dgv.CurrentCellAddress.Y.ToString();
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dgv[7, 7].Value.ToString(), "OK");
            int namex = Convert.ToInt32(txtNameCellX.Text);
            int namey = Convert.ToInt32(txtNameCellY.Text);
            int gradex = Convert.ToInt32(txtGradeCellX.Text);
            int gradey = Convert.ToInt32(txtGradeCellY.Text);

            string name, grade;

            if (!cboSubjects.Items.Contains(cboSubjects.Text))
            {
                MessageBox.Show(UIStrings.L.INVALID_SUBJECT, UIStrings.L.INVALID_SUBJECT_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string subject = subjectNameToCode[cboSubjects.Text];
            Dictionary<String, String> data;

            while (gradey < dgv.Rows.Count)
            {
                if (dgv[gradex, gradey].Value.ToString().Trim().Length > 0)
                {
                    if (dgv[namex, namey].Value.ToString().Trim().Length > 0)
                    {
                        name = dgv[namex, namey].Value.ToString().Trim();
                        grade = dgv[gradex, gradey].Value.ToString().Trim();
                        DataTable names = DB.mainDB.GetDataTable(String.Format("SELECT StudentCourse, StudentNumber FROM Student_Data WHERE FName | ' ' | LName = '{0}';", name));
                        if (names.Rows.Count == 0)
                        {
                            MessageBox.Show(UIStrings.L.NAME_NOT_FOUND + name, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (names.Rows.Count > 1)
                        {
                            MessageBox.Show(UIStrings.L.MULTIPLE_NAMES_FOUND + name, UIStrings.L.ADD_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        data = new Dictionary<String, String>();
                        data["StudentNumber"] = names.Rows[0]["StudentNumber"].ToString();
                        data["StudentCourse"] = names.Rows[0]["StudentCourse"].ToString();
                        data["SubjectCode"] = subject;
                        data["FinalGrade"] = Convert.ToDouble(grade) > 3 ? "FAILED" : grade;
                        DB.mainDB.Insert("Student_EnrolledSubjects", data);
                    }
                }
                gradey++;
                namey++;
            }
            MessageBox.Show(UIStrings.L.IMPORT_OK, UIStrings.L.IMPORT_OK_L, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
