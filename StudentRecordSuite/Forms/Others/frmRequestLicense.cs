using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace StudentRecordSuite
{
    public partial class frmRequestLicense : Form
    {
        public frmRequestLicense()
        {
            InitializeComponent();
        }

        private void frmRequestLicense_Load(object sender, EventArgs e)
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string localhost = computerProperties.HostName;
            byte mask = 0;
            mask = 0;
            foreach (char c in localhost)
            {
                mask += (byte)c;
            }
            mask = (byte)(mask << 1);

            bool found = false;
            string macstring = "000000000000";
            foreach (NetworkInterface adapter in nics)
            {
                if (!(
                       adapter.Description.Contains("Microsoft") ||
                       adapter.Description.Contains("Virtual") ||
                       adapter.Description.Contains("TAP") ||
                       adapter.Description.Contains("Software") ||
                       adapter.Description.Contains("Loopback")
                       ) && (!found))
                    {
                        macstring = adapter.GetPhysicalAddress().ToString().Replace("-", "");
                        found = true;
                    }
            }

            txtRequest.Text = macstring + BitConverter.ToString(new byte[1] {(byte)mask}) + "1";
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
