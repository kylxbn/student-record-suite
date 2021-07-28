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
    public partial class frmGetLicense : Form
    {
        public frmGetLicense()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            SQLiteDatabase license = new SQLiteDatabase(FilePaths.LICENSE);
            if (!license.DBExists())
            {
                license.CreateDB();
            }
            license.ExecuteNonQuery("DROP TABLE IF EXISTS License;");
            license.ExecuteNonQuery("CREATE TABLE License (Key VARCHAR);");
            license.ExecuteNonQuery(string.Format("INSERT INTO License VALUES ('{0}');", txtSerial.Text));
            Application.Restart();
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            if (txtSerial.Text.Length < 25)
                cmdSubmit.Enabled = false;
            else
                cmdSubmit.Enabled = true;
        }

        private void frmGetLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
