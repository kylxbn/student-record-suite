using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentRecordSuite
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if program configuration database exists
            DB.configDB = new SQLiteDatabase(FilePaths.MASTER_CONFIG);
            if (!DB.configDB.DBExists())
            {
                // Initialize configuration & Build database
                Application.Run(new frmSetLanguage());
                Application.Run(new frmFirstProgramConfig());
            }
            
            ProgramConfig.LoadConfig();

            // check if main database exists
            SQLiteDatabase mainDB = new SQLiteDatabase(ProgramConfig.DBPath);
            if (!mainDB.DBExists())
            {
                // Somebody deleted the main database, so let's build it again.
                MessageBox.Show(UIStrings.L.DB_NOT_FOUND, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Run(new frmFirstProgramConfig());
            }

            ProgramConfig.LoadConfig();

            Application.Run(new frmLogIn());
            Application.Run(new frmMain());
        }
    }
}
