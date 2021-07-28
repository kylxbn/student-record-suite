namespace StudentRecordSuite
{
    partial class frmGetLicense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetLicense));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.MaskedTextBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtSerial
            // 
            resources.ApplyResources(this.txtSerial, "txtSerial");
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtSerial.TextChanged += new System.EventHandler(this.txtSerial_TextChanged);
            // 
            // cmdSubmit
            // 
            resources.ApplyResources(this.cmdSubmit, "cmdSubmit");
            this.cmdSubmit.Image = global::StudentRecordSuite.Properties.Resources.key;
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdExit
            // 
            resources.ApplyResources(this.cmdExit, "cmdExit");
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmGetLicense
            // 
            this.AcceptButton = this.cmdSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetLicense";
            this.Load += new System.EventHandler(this.frmGetLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtSerial;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdExit;
    }
}