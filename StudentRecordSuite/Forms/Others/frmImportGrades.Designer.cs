namespace StudentRecordSuite
{
    partial class frmImportGrades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportGrades));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.openDlg = new System.Windows.Forms.OpenFileDialog();
            this.txtSheet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoad = new System.Windows.Forms.Button();
            this.txtNameCellX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGradeCellX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdNameCurrent = new System.Windows.Forms.Button();
            this.cmdGradeCurrent = new System.Windows.Forms.Button();
            this.cboSubjects = new System.Windows.Forms.ComboBox();
            this.txtNameCellY = new System.Windows.Forms.TextBox();
            this.txtGradeCellY = new System.Windows.Forms.TextBox();
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtPath
            // 
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.Name = "dgv";
            // 
            // txtSheet
            // 
            resources.ApplyResources(this.txtSheet, "txtSheet");
            this.txtSheet.Name = "txtSheet";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtLoad
            // 
            resources.ApplyResources(this.txtLoad, "txtLoad");
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.UseVisualStyleBackColor = true;
            this.txtLoad.Click += new System.EventHandler(this.txtLoad_Click);
            // 
            // txtNameCellX
            // 
            resources.ApplyResources(this.txtNameCellX, "txtNameCellX");
            this.txtNameCellX.Name = "txtNameCellX";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtGradeCellX
            // 
            resources.ApplyResources(this.txtGradeCellX, "txtGradeCellX");
            this.txtGradeCellX.Name = "txtGradeCellX";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cmdNameCurrent
            // 
            resources.ApplyResources(this.cmdNameCurrent, "cmdNameCurrent");
            this.cmdNameCurrent.Name = "cmdNameCurrent";
            this.cmdNameCurrent.UseVisualStyleBackColor = true;
            this.cmdNameCurrent.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdGradeCurrent
            // 
            resources.ApplyResources(this.cmdGradeCurrent, "cmdGradeCurrent");
            this.cmdGradeCurrent.Name = "cmdGradeCurrent";
            this.cmdGradeCurrent.UseVisualStyleBackColor = true;
            this.cmdGradeCurrent.Click += new System.EventHandler(this.cmdGradeCurrent_Click);
            // 
            // cboSubjects
            // 
            this.cboSubjects.FormattingEnabled = true;
            resources.ApplyResources(this.cboSubjects, "cboSubjects");
            this.cboSubjects.Name = "cboSubjects";
            // 
            // txtNameCellY
            // 
            resources.ApplyResources(this.txtNameCellY, "txtNameCellY");
            this.txtNameCellY.Name = "txtNameCellY";
            // 
            // txtGradeCellY
            // 
            resources.ApplyResources(this.txtGradeCellY, "txtGradeCellY");
            this.txtGradeCellY.Name = "txtGradeCellY";
            // 
            // cmdImport
            // 
            this.cmdImport.Image = global::StudentRecordSuite.Properties.Resources.add;
            resources.ApplyResources(this.cmdImport, "cmdImport");
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // frmImportGrades
            // 
            this.AcceptButton = this.cmdImport;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.txtGradeCellY);
            this.Controls.Add(this.txtNameCellY);
            this.Controls.Add(this.cboSubjects);
            this.Controls.Add(this.cmdGradeCurrent);
            this.Controls.Add(this.cmdNameCurrent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGradeCellX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameCellX);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSheet);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportGrades";
            this.Load += new System.EventHandler(this.frmImportGrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.OpenFileDialog openDlg;
        private System.Windows.Forms.TextBox txtSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button txtLoad;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.TextBox txtNameCellX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGradeCellX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdNameCurrent;
        private System.Windows.Forms.Button cmdGradeCurrent;
        private System.Windows.Forms.ComboBox cboSubjects;
        private System.Windows.Forms.TextBox txtNameCellY;
        private System.Windows.Forms.TextBox txtGradeCellY;
    }
}