using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Net.NetworkInformation;

namespace StudentRecordSuite
{
    static class SoftwareLicense
    {
        public static string Licensee;

        public static void DeleteLicense()
        {
            SQLiteDatabase license = new SQLiteDatabase(FilePaths.LICENSE);
            if (!license.DBExists())
            {
                license.CreateDB();
                license.ExecuteNonQuery("CREATE TABLE License (Key VARCHAR);");
            }
            license.ExecuteNonQuery("DROP TABLE IF EXISTS License;");
        }

        public static bool CheckLicense()
        {
            SQLiteDatabase license = new SQLiteDatabase(FilePaths.LICENSE);
            if (!license.DBExists())
            {
                license.CreateDB();
                license.ExecuteNonQuery("CREATE TABLE License (Key VARCHAR);");
            }
            DataTable dt = license.GetDataTable("SELECT Key FROM License;");
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            string s = dt.Rows[0]["Key"].ToString();
            bool valid = false;
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string localhost = computerProperties.HostName;
            byte mask = 0;
            foreach (char c in localhost)
            {
                mask += (byte)c;
            }
            mask = (byte)(mask << 1);
            byte[] serial = new byte[12];
            for (int i = 0; i < 12; i++)
            {
                serial[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            }
            long cs = 0;
            for (int i = 0; i < 12; i++)
            {
                cs += serial[i];
            }
            cs = cs % 16;
            if (BitConverter.ToString(new byte[] { (byte)cs }).Replace("-", "").Substring(1, 1) != s.Substring(24, 1))
            {
                return false;
            }
            for (int i = 0; i < 12; i++)
            {
                serial[i] = (byte)(serial[i] ^ mask);
            }
            byte[] mac = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mac[i] = (byte)(mac[i] >> 1);
                    if (j < 4)
                    {
                        mac[i] += (byte)(serial[i * 2] & 0x80);
                        serial[i * 2] = (byte)(serial[i * 2] << 2);
                    }
                    else
                    {
                        mac[i] += (byte)(serial[i * 2 + 1] & 0x80);
                        serial[i * 2 + 1] = (byte)(serial[i * 2 + 1] << 2);
                    }
                }
            }
            string macstring = BitConverter.ToString(mac).Replace("-", "");
            foreach (NetworkInterface adapter in nics)
            {
                if (!(
                       adapter.Description.Contains("Microsoft") ||
                       adapter.Description.Contains("Virtual") ||
                       adapter.Description.Contains("TAP") ||
                       adapter.Description.Contains("Software") ||
                       adapter.Description.Contains("Loopback")
                       ))
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    if (adapter.GetPhysicalAddress().ToString() == macstring) valid = true;
                }
            }
            if (valid)
            {
                Licensee = macstring;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
