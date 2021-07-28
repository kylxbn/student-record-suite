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
    public partial class frmProgramConfig : Form
    {
        Form main;

        public frmProgramConfig(Form m)
        {
            InitializeComponent();
            main = m;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool restart = false;
            if (ProgramConfig.language == 1)
            {
                if (cboLanguage.Text == "英語")
                {
                    ProgramConfig.language = 0;
                    restart = true;
                }
                if (cboLanguage.Text == "エスペラント語")
                {
                    ProgramConfig.language = 2;
                    restart = true;
                }
            }
            else if (ProgramConfig.language == 0)
            {
                if (cboLanguage.Text == "Japanese")
                {
                    ProgramConfig.language = 1;
                    restart = true;
                }
                else if (cboLanguage.Text == "Esperanto")
                {
                    ProgramConfig.language = 2;
                    restart = true;
                }
            }
            else if (ProgramConfig.language == 2)
            {
                if (cboLanguage.Text == "Japana")
                {
                    ProgramConfig.language = 1;
                    restart = true;
                }
                else if (cboLanguage.Text == "Angla")
                {
                    ProgramConfig.language = 0;
                    restart = true;
                }
            }
            ProgramConfig.DBPath = txtDBPath.Text;
            ProgramConfig.nongradUnits = Convert.ToInt32(txtNonGraduating.Text);
            ProgramConfig.gradUnits = Convert.ToInt32(txtGraduating.Text);
            if (restart)
            {
                ProgramConfig.windowWidth = main.Size.Width;
                ProgramConfig.windowHeight = main.Size.Height;
                ProgramConfig.windowX = main.Location.X;
                ProgramConfig.windowY = main.Location.Y;
                ProgramConfig.WriteConfig(false);
                Application.Restart();
            }
            ProgramConfig.WriteConfig(false);
            this.Dispose();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmProgramConfig_Load(object sender, EventArgs e)
        {
            if (ProgramConfig.language == 1)
            {
                cboLanguage.Text = "日本語";
            }
            else if (ProgramConfig.language == 0)
            {
                cboLanguage.Text = "English";
            }
            else if (ProgramConfig.language == 2)
            {
                cboLanguage.Text = "Esperanto";
            }

            txtDBPath.Text = ProgramConfig.DBPath;
            txtGraduating.Text = ProgramConfig.gradUnits.ToString();
            txtNonGraduating.Text = ProgramConfig.nongradUnits.ToString();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            dlgFolder.ShowDialog();
            if (dlgFolder.FileName.Trim().Length != 0)
                txtDBPath.Text = dlgFolder.FileName.Trim();
        }
    }
}
