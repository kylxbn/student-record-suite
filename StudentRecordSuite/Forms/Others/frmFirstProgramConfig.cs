using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace StudentRecordSuite
{
    public partial class frmFirstProgramConfig : Form
    {

        public frmFirstProgramConfig()
        {
            
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            /*if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Please enter a password.");
                return;
            }*/

            ProgramConfig.DBPath = txtDBPath.Text;
            ProgramConfig.WriteConfig(true);

            if (radioButton1.Checked)
            {
                if (txtUsername.Text.Trim().Length < 1)
                {
                    MessageBox.Show(UIStrings.L.BLANK_USERNAME, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Tools.CreateDatabase(txtUsername.Text, txtPassword.Text);

            }
            else
            {
                if (txtSource.Text.Trim().Length == 0)
                {
                    MessageBox.Show(UIStrings.L.CHOOSE_FILE, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                System.IO.File.Copy(txtSource.Text, txtDBPath.Text);
            }
            if (ProgramConfig.language == 0)
                MessageBox.Show("Database successfuly created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (ProgramConfig.language == 1)
                MessageBox.Show("データベースが正常に作成されました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Sukcese kreis datumbazon.", "Sukcese", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            dlgFolder.ShowDialog();
            if (dlgFolder.FileName.Trim().Length != 0)
                txtDBPath.Text = dlgFolder.FileName.Trim();
        }

        private void cmdBrowseSource_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Trim().Length != 0)
                txtSource.Text = openFileDialog1.FileName.Trim();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblSource.Enabled = false;
            cmdBrowseSource.Enabled = false;
            lblPassword.Enabled = true;
            lblPassword2.Enabled = true;
            lblUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtPassword2.Enabled = true;
            txtUsername.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblSource.Enabled = true;
            cmdBrowseSource.Enabled = true;
            lblPassword.Enabled = false;
            lblPassword2.Enabled = false;
            lblUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtPassword2.Enabled = false;
            txtUsername.Enabled = false;

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPassword2.Text)
                cmdSave.Enabled = false;
            else
                cmdSave.Enabled = true;
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPassword2.Text)
                cmdSave.Enabled = false;
            else
                cmdSave.Enabled = true;
        }

        private void txtDBPath_TextChanged(object sender, EventArgs e)
        {
            if (txtDBPath.Text.Trim().Length == 0)
                cmdSave.Enabled = false;
            else
                cmdSave.Enabled = true;
        }
    }
}
