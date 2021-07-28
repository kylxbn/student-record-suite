using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;

namespace StudentRecordSuite
{
    public partial class frmMain : Form
    {
        DataTable dt;

        public frmMain()
        {
            InitializeComponent();
            DB.mainDB = new SQLiteDatabase(ProgramConfig.DBPath, ProgramConfig.password);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new frmAbout();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramConfig.windowWidth = this.Size.Width;
            ProgramConfig.windowHeight = this.Size.Height;
            ProgramConfig.windowX = this.Location.X;
            ProgramConfig.windowY = this.Location.Y;
            ProgramConfig.WriteConfig();
            Application.Exit();
        }

        private void softwareLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form l = new frmCheckLicense();
                l.ShowDialog();
            }
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB.mainDB.ExecuteNonQuery("DROP TABLE IF EXISTS Debug;");
            DB.mainDB.ExecuteNonQuery("CREATE TABLE Debug (A VARCHAR, B VARCHAR);");
            DB.mainDB.ExecuteNonQuery("INSERT INTO Debug VALUES ('X', 'Y');");
            MessageBox.Show("Debugged!");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            this.Location = new Point(ProgramConfig.windowX, ProgramConfig.windowY);
            if (!SoftwareLicense.CheckLicense())
            {
                txtSearchFName.Enabled = false;
                txtSearchLName.Enabled = false;
                txtSearchCourse.Enabled = false;
                txtSearchStudentNo.Enabled = false;
                cmdResetSearch.Enabled = false;
                mnuDGV.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                generateToolStripMenuItem.Enabled = false;
                programSettingsToolStripMenuItem.Enabled = false;
                lblStatus.Text = UIStrings.L.NO_SERIAL;
                importGradesFromExcelToolStripMenuItem.Enabled = false;
                backupDatabaseToolStripMenuItem.Enabled = false;
            }
            else
                lblStatus.Text = "Ready.";

            this.Text = "StudentRecordSuite v2.1 - " + ProgramConfig.username + " (" + (ProgramConfig.usertype == 0 ? "Admin" : (ProgramConfig.usertype == 1 ? "Authorized" : "Limited")) + ")";
        }

        private void programSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form settings = new frmProgramConfig(this);
                settings.ShowDialog();
            }
        }

        private void enrollStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form enrollStudent = new frmAddStudent();
                enrollStudent.ShowDialog();
            }
        }

        private void addSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form addSubject = new frmAddSubject();
                addSubject.ShowDialog();
            }


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            SearchStudent();
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void SearchStudent()
        {
            string sql = "SELECT LName 'Surname', FName 'First name', StudentCourse || SUBSTR(PRINTF('%06d', StudentNumber), 1, 2) || '-' || SUBSTR(PRINTF('%06d', StudentNumber), 3, 4) 'ID' FROM Student_Data WHERE ";
            string add = "";
            string LName = txtSearchLName.Text;
            string FName = txtSearchFName.Text;
            string course = txtSearchCourse.Text;
            string id = txtSearchStudentNo.Text;
            bool sL = LName != "Surname";
            bool sF = FName != "First name";
            bool sC = course != "Course";
            bool sI = id.Trim() != "";

            if (sL || sF || sC || sI)
            {
                lblStatus.Text = "Searching...";
                if (sL)
                    add = string.Format("LName LIKE '{0}%'", LName);
                if (sF)
                {
                    if (sL) add += " AND ";
                    add += string.Format("FName LIKE '{0}%'", FName);
                }
                if (sC)
                {
                    if (sL || sF) add += " AND ";
                    add += string.Format("StudentCourse LIKE '{0}%'", course);
                }
                if (sI)
                {
                    if (sL || sF || sC) add += " AND ";
                    add += string.Format("StudentNumber LIKE '{0}%'", id);
                }
                add += " LIMIT 100;";
                sql += add;
                dt = DB.mainDB.GetDataTable(sql);
                dgvResults.DataSource = dt;
                lblStatus.Text = string.Format("{0} record(s) found.", dt.Rows.Count);
            }
        }

        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form rs = new frmRemoveStudent();
                rs.ShowDialog();
            }

        }

        private void txtStudentID_Enter(object sender, EventArgs e)
        {
            txtSearchStudentNo.SelectionStart = 0;
        }

        private void txtSearchCourse_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void txtSearchFName_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private string TitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        private string TitleCaseAcronym(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        private void txtSearchCourse_Enter(object sender, EventArgs e)
        {
            if (txtSearchCourse.Text == "Course")
            {
                txtSearchCourse.Text = "";
                txtSearchCourse.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtSearchCourse_Leave(object sender, EventArgs e)
        {
            if (txtSearchCourse.Text.Trim() == "")
            {
                txtSearchCourse.Text = "Course";
                txtSearchCourse.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearchFName_Enter(object sender, EventArgs e)
        {
            if (txtSearchFName.Text == "First name")
            {
                txtSearchFName.Text = "";
                txtSearchFName.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtSearchFName_Leave(object sender, EventArgs e)
        {
            if (txtSearchFName.Text.Trim() == "")
            {
                txtSearchFName.Text = "First name";
                txtSearchFName.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearchLName_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void txtSearchLName_Leave(object sender, EventArgs e)
        {
            if (txtSearchLName.Text.Trim() == "")
            {
                txtSearchLName.Text = "Surname";
                txtSearchLName.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearchLName_Enter(object sender, EventArgs e)
        {
            if (txtSearchLName.Text == "Surname")
            {
                txtSearchLName.Text = "";
                txtSearchLName.ForeColor = SystemColors.WindowText;
            }
        }

        private void searchForAStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form edit = new frmEditStudent();
            edit.ShowDialog();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form addCourse = new frmAddCourse();
                addCourse.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmdResetSearch_Click(object sender, EventArgs e)
        {
            /*txtSearchLName.Text = "";
            txtSearchFName.Text = "";
            txtSearchCourse.Text = "";
            txtSearchStudentNo.Text = "";*/
            txtSearchLName.Text = "";
            txtSearchLName.ForeColor = SystemColors.WindowText;
            txtSearchFName.Text = "First name";
            txtSearchFName.ForeColor = SystemColors.GrayText;
            txtSearchCourse.Text = "Course";
            txtSearchCourse.ForeColor = SystemColors.GrayText;
            txtSearchStudentNo.Text = "";
            txtSearchLName.Focus();
        }

        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ed = new frmEditStudent(dt.Rows[dgvResults.CurrentCell.RowIndex]["ID"].ToString());
            ed.ShowDialog();
        }

        private void autoRefresh_Tick(object sender, EventArgs e)
        {
            autoRefresh.Stop();
            SearchStudent();
            autoRefresh.Start();
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form ed = new frmRemoveStudent(dt.Rows[dgvResults.CurrentCell.RowIndex]["ID"].ToString());
                ed.ShowDialog();
            }
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form ed = new frmAddStudent();
                ed.ShowDialog();
            }

        }

        private void viewEditSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form edits = new frmEditSubject();
            edits.ShowDialog();
        }

        private void removeSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form delete = new frmDeleteSubject();
                delete.ShowDialog();
            }

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form editcourse = new frmEditCourse();
            editcourse.ShowDialog();
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form delcourse = new frmRemoveCourse();
                delcourse.ShowDialog();
            }

        }

        private void advanceAStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form enroll = new frmEnrollStudent();
                enroll.ShowDialog();
            }

        }

        private void advanceStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form enroll = new frmEnrollStudent(dt.Rows[dgvResults.CurrentCell.RowIndex]["ID"].ToString());
                enroll.ShowDialog();
            }
        }

        private void enterGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form enter = new frmEnterGrades();
                enter.ShowDialog();
            }

        }

        private void enterGradesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form enter = new frmEnterGrades(dt.Rows[dgvResults.CurrentCell.RowIndex]["ID"].ToString());
                enter.ShowDialog();
            }

        }

        private void importGradesFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form im = new frmImportGrades();
                im.ShowDialog();
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewEnrolledSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sub = new frmViewEnrolled(dt.Rows[dgvResults.CurrentCell.RowIndex]["ID"].ToString());
            sub.ShowDialog();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(ProgramConfig.DBPath));
            }
            System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(ProgramConfig.DBPath));
        }

        private void tORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sub = new frmViewEnrolled();
            sub.ShowDialog();
        }

        private void mnuDGV_Opening(object sender, CancelEventArgs e)
        {
            if (dgvResults.CurrentCell == null)
            {
                editStudentToolStripMenuItem.Enabled = false;
                deleteStudentToolStripMenuItem.Enabled = false;
                viewEnrolledSubjectsToolStripMenuItem.Enabled = false;
                advanceStudentToolStripMenuItem.Enabled = false;
                enterGradesToolStripMenuItem1.Enabled = false;
            }
            else
            {
                editStudentToolStripMenuItem.Enabled = true;
                deleteStudentToolStripMenuItem.Enabled = true;
                viewEnrolledSubjectsToolStripMenuItem.Enabled = true;
                advanceStudentToolStripMenuItem.Enabled = true;
                enterGradesToolStripMenuItem1.Enabled = true;
            }
        }

        private void changeDatabasePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 0)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Form settings = new frmEditUsers();
                settings.ShowDialog();
            }
        }
    }
}
