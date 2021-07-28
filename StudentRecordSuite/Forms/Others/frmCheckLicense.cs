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
    public partial class frmCheckLicense : Form
    {
        public frmCheckLicense()
        {
            InitializeComponent();
        }

        private void frmCheckLicense_Load(object sender, EventArgs e)
        {
            if (SoftwareLicense.CheckLicense())
            {
                lblLicensed.Visible = true;
                lblLicensed.Text = UIStrings.L.LICENSED_TO;
                txtLicensee.Visible = true;
                txtLicensee.Text = SoftwareLicense.Licensee;
                cmdLicense.Visible = true;
                cmdLicense.Text = UIStrings.L.REENTER_LICENSE;
                cmdClose.Visible = true;
            }
            else
            {
                lblLicensed.Visible = true;
                lblLicensed.Text = UIStrings.L.NOT_LICENSED;
                txtLicensee.Visible = false;
                cmdLicense.Visible = true;
                cmdLicense.Text = UIStrings.L.ENTER_LICENSE;
                cmdClose.Visible = true;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdEnterLicense_Click(object sender, EventArgs e)
        {
            Form l = new frmGetLicense();
            l.ShowDialog();
        }

        private void cmdRequest_Click(object sender, EventArgs e)
        {
            Form getLic = new frmRequestLicense();
            getLic.ShowDialog();
        }
    }
}
