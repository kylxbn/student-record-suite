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
    public partial class frmEditUsers : Form
    {
        public frmEditUsers()
        {
            InitializeComponent();
        }

        private void frmEditUsers_Load(object sender, EventArgs e)
        {
            cboSearch.Items.Add("--New user--");
            DataTable users = DB.mainDB.GetDataTable("SELECT * FROM Users;");
            foreach (DataRow username in users.Rows)
            {
                cboSearch.Items.Add(username["Username"].ToString());
            }
            cboSearch.SelectedIndex = 0;
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable user = DB.mainDB.GetDataTable("SELECT * FROM Users WHERE Username = '" + cboSearch.Text + "';");
            if (user.Rows.Count > 0)
            {
                DataRow u = user.Rows[0];
                txtUsername.Text = u["Username"].ToString();
                txtPassword.Text = u["Password"].ToString();
                txtPassword2.Text = u["Password"].ToString();
                cboType.SelectedIndex = Convert.ToInt32(u["Type"].ToString());
                cmdSubmit.Text = "Update";
                cmdRemove.Enabled = true;
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtPassword2.Text = "";
                cboType.SelectedIndex = 2;
                cmdSubmit.Text = "Add";
                cmdRemove.Enabled = false;
            }

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPassword2.Text)
            {
                MessageBox.Show("The two passwords don't match.", UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (cmdSubmit.Text == "Update")
            {
                DataTable s = DB.mainDB.GetDataTable("SELECT * FROM Users WHERE Username = '" + cboSearch.Text + "';");
                if (Convert.ToInt32(s.Rows[0]["Type"].ToString()) == 0)
                {
                    if (cboType.SelectedIndex > 0)
                    {
                        DataTable admins = DB.mainDB.GetDataTable("SELECT * FROM Users WHERE Type = 0;");
                        if (admins.Rows.Count - 1 < 1)
                        {
                            MessageBox.Show("If you downgrade this Administrator account,\nthere will be no administrators,\nand nobody will be able to edit users.", UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }

                Dictionary<string, string> data = new Dictionary<string, string>();
                data["Username"] = txtUsername.Text;
                data["Password"] = txtPassword.Text;
                data["Type"] = cboType.SelectedIndex.ToString();
                DB.mainDB.Update("Users", data, "Username = '" + cboSearch.Text + "';");
                MessageBox.Show("User updated.", UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else if (cmdSubmit.Text == "Add")
            {
                DataTable s = DB.mainDB.GetDataTable("SELECT * FROM Users WHERE Username = '" + cboSearch.Text + "';");
                if (s.Rows.Count > 0)
                {
                    MessageBox.Show("This user already exists.", UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["Username"] = txtUsername.Text;
                data["Password"] = txtPassword.Text;
                data["Type"] = cboType.SelectedIndex.ToString();
                DB.mainDB.Insert("Users", data);
                MessageBox.Show("User added.", UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                DataTable admins = DB.mainDB.GetDataTable("SELECT * FROM Users WHERE Type = 0;");
                if (admins.Rows.Count - 1 < 1)
                {
                    MessageBox.Show("If you delete this Administrator account,\nthere will be no administrators,\nand nobody will be able to edit users.", UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            DB.mainDB.Delete("Users", "Username = '" + cboSearch.Text + "';");
            MessageBox.Show("User deleted.", UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.SelectedIndex)
            {
                case 0:
                    lblExplanation.Text = "This user can view and modify anything.";
                    break;
                case 1:
                    lblExplanation.Text = "This user can view and modify anything except the users.";
                    break;
                case 2:
                    lblExplanation.Text = "This user can only view data, but cannot modify anything.";
                    break;
            }
        }
    }
}
