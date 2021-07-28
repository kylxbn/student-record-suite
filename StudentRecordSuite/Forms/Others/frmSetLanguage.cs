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
    public partial class frmSetLanguage : Form
    {
        public frmSetLanguage()
        {
            InitializeComponent();
        }

        private void cmdEnglish_Click(object sender, EventArgs e)
        {
            ProgramConfig.language = 0;
            UIStrings.L = new English();
            this.Dispose();
        }

        private void cmdJapanese_Click(object sender, EventArgs e)
        {
            ProgramConfig.language = 1;
            UIStrings.L = new Japanese();
            this.Dispose();
        }

        private void frmSetLanguage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgramConfig.language = 2;
            UIStrings.L = new Esperanto();
            this.Dispose();
        }


    }
}

