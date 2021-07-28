namespace StudentRecordSuite
{
    partial class frmRemoveCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemoveCourse));
            this.cboCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkConfirm = new System.Windows.Forms.CheckBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboCode
            // 
            this.cboCode.FormattingEnabled = true;
            resources.ApplyResources(this.cboCode, "cboCode");
            this.cboCode.Name = "cboCode";
            this.cboCode.Sorted = true;
            this.cboCode.SelectedIndexChanged += new System.EventHandler(this.cboCode_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cboName
            // 
            this.cboName.FormattingEnabled = true;
            resources.ApplyResources(this.cboName, "cboName");
            this.cboName.Name = "cboName";
            this.cboName.Sorted = true;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // chkConfirm
            // 
            resources.ApplyResources(this.chkConfirm, "chkConfirm");
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = global::StudentRecordSuite.Properties.Resources.delete;
            resources.ApplyResources(this.cmdDelete, "cmdDelete");
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRemoveCourse
            // 
            this.AcceptButton = this.cmdDelete;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.chkConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemoveCourse";
            this.Load += new System.EventHandler(this.frmRemoveCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkConfirm;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button button1;
    }
}