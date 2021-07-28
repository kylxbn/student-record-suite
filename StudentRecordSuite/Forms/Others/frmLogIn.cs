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
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdLogIn_Click(object sender, EventArgs e)
        {
            DB.mainDB = new SQLiteDatabase(ProgramConfig.DBPath, ProgramConfig.password);
            DataTable test = DB.mainDB.GetDataTable(String.Format("SELECT * FROM Users WHERE Username = '{0}' AND Password = '{1}';", txtUsername.Text, txtPassword.Text));
            if (test.Rows.Count == 0)
            {
                MessageBox.Show(UIStrings.L.WRONG_PASSWORD, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                ProgramConfig.username = txtUsername.Text;
                ProgramConfig.usertype = Convert.ToInt32(test.Rows[0]["Type"].ToString());
                this.Dispose();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            
        }
    }
}
