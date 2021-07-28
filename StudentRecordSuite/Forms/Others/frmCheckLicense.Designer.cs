namespace StudentRecordSuite
{
    partial class frmCheckLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckLicense));
            this.lblLicensed = new System.Windows.Forms.Label();
            this.txtLicensee = new System.Windows.Forms.TextBox();
            this.cmdRequest = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdLicense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLicensed
            // 
            resources.ApplyResources(this.lblLicensed, "lblLicensed");
            this.lblLicensed.Name = "lblLicensed";
            // 
            // txtLicensee
            // 
            resources.ApplyResources(this.txtLicensee, "txtLicensee");
            this.txtLicensee.Name = "txtLicensee";
            // 
            // cmdRequest
            // 
            this.cmdRequest.Image = global::StudentRecordSuite.Properties.Resources.transmit_blue;
            resources.ApplyResources(this.cmdRequest, "cmdRequest");
            this.cmdRequest.Name = "cmdRequest";
            this.cmdRequest.UseVisualStyleBackColor = true;
            this.cmdRequest.Click += new System.EventHandler(this.cmdRequest_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdLicense
            // 
            this.cmdLicense.Image = global::StudentRecordSuite.Properties.Resources.key;
            resources.ApplyResources(this.cmdLicense, "cmdLicense");
            this.cmdLicense.Name = "cmdLicense";
            this.cmdLicense.UseVisualStyleBackColor = true;
            this.cmdLicense.Click += new System.EventHandler(this.cmdEnterLicense_Click);
            // 
            // frmCheckLicense
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdRequest);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdLicense);
            this.Controls.Add(this.txtLicensee);
            this.Controls.Add(this.lblLicensed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckLicense";
            this.Load += new System.EventHandler(this.frmCheckLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLicensed;
        private System.Windows.Forms.TextBox txtLicensee;
        private System.Windows.Forms.Button cmdLicense;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdRequest;
    }
}