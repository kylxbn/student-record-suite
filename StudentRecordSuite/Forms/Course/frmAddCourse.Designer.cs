namespace StudentRecordSuite
{
    partial class frmAddCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddCourse));
            this.lstYear = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSemester = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSubjects = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSubjects = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAddYear = new System.Windows.Forms.Button();
            this.cmdRemoveYear = new System.Windows.Forms.Button();
            this.cmdAddSemester = new System.Windows.Forms.Button();
            this.cmdRemoveSemester = new System.Windows.Forms.Button();
            this.cmdAddSubject = new System.Windows.Forms.Button();
            this.cmdRemoveSubject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstYear
            // 
            this.lstYear.FormattingEnabled = true;
            resources.ApplyResources(this.lstYear, "lstYear");
            this.lstYear.Name = "lstYear";
            this.lstYear.Sorted = true;
            this.lstYear.SelectedIndexChanged += new System.EventHandler(this.lstYear_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lstSemester
            // 
            this.lstSemester.FormattingEnabled = true;
            resources.ApplyResources(this.lstSemester, "lstSemester");
            this.lstSemester.Name = "lstSemester";
            this.lstSemester.Sorted = true;
            this.lstSemester.SelectedIndexChanged += new System.EventHandler(this.lstSemester_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lstSubjects
            // 
            this.lstSubjects.FormattingEnabled = true;
            resources.ApplyResources(this.lstSubjects, "lstSubjects");
            this.lstSubjects.Name = "lstSubjects";
            this.lstSubjects.Sorted = true;
            this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cboSubjects
            // 
            this.cboSubjects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSubjects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSubjects.FormattingEnabled = true;
            resources.ApplyResources(this.cboSubjects, "cboSubjects");
            this.cboSubjects.Name = "cboSubjects";
            this.cboSubjects.Sorted = true;
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtAbbreviation, "txtAbbreviation");
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Leave += new System.EventHandler(this.txtAbbreviation_Leave);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Image = global::StudentRecordSuite.Properties.Resources.add;
            resources.ApplyResources(this.cmdSubmit, "cmdSubmit");
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAddYear
            // 
            this.cmdAddYear.Image = global::StudentRecordSuite.Properties.Resources.add;
            resources.ApplyResources(this.cmdAddYear, "cmdAddYear");
            this.cmdAddYear.Name = "cmdAddYear";
            this.cmdAddYear.UseVisualStyleBackColor = true;
            this.cmdAddYear.Click += new System.EventHandler(this.cmdAddYear_Click);
            // 
            // cmdRemoveYear
            // 
            resources.ApplyResources(this.cmdRemoveYear, "cmdRemoveYear");
            this.cmdRemoveYear.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemoveYear.Name = "cmdRemoveYear";
            this.cmdRemoveYear.UseVisualStyleBackColor = true;
            this.cmdRemoveYear.Click += new System.EventHandler(this.cmdRemoveYear_Click);
            // 
            // cmdAddSemester
            // 
            resources.ApplyResources(this.cmdAddSemester, "cmdAddSemester");
            this.cmdAddSemester.Image = global::StudentRecordSuite.Properties.Resources.add;
            this.cmdAddSemester.Name = "cmdAddSemester";
            this.cmdAddSemester.UseVisualStyleBackColor = true;
            this.cmdAddSemester.Click += new System.EventHandler(this.cmdAddSemester_Click);
            // 
            // cmdRemoveSemester
            // 
            resources.ApplyResources(this.cmdRemoveSemester, "cmdRemoveSemester");
            this.cmdRemoveSemester.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemoveSemester.Name = "cmdRemoveSemester";
            this.cmdRemoveSemester.UseVisualStyleBackColor = true;
            this.cmdRemoveSemester.Click += new System.EventHandler(this.cmdRemoveSemester_Click);
            // 
            // cmdAddSubject
            // 
            resources.ApplyResources(this.cmdAddSubject, "cmdAddSubject");
            this.cmdAddSubject.Image = global::StudentRecordSuite.Properties.Resources.add;
            this.cmdAddSubject.Name = "cmdAddSubject";
            this.cmdAddSubject.UseVisualStyleBackColor = true;
            this.cmdAddSubject.Click += new System.EventHandler(this.cmdAddSubject_Click);
            // 
            // cmdRemoveSubject
            // 
            resources.ApplyResources(this.cmdRemoveSubject, "cmdRemoveSubject");
            this.cmdRemoveSubject.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemoveSubject.Name = "cmdRemoveSubject";
            this.cmdRemoveSubject.UseVisualStyleBackColor = true;
            this.cmdRemoveSubject.Click += new System.EventHandler(this.cmdRemoveSubject_Click);
            // 
            // frmAddCourse
            // 
            this.AcceptButton = this.cmdSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAbbreviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAddYear);
            this.Controls.Add(this.cmdRemoveYear);
            this.Controls.Add(this.cmdAddSemester);
            this.Controls.Add(this.cmdRemoveSemester);
            this.Controls.Add(this.cmdAddSubject);
            this.Controls.Add(this.cmdRemoveSubject);
            this.Controls.Add(this.cboSubjects);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstSubjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSemester);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstYear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCourse";
            this.Load += new System.EventHandler(this.frmAddCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSemester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSubjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.ComboBox cboSubjects;
        private System.Windows.Forms.Button cmdRemoveSubject;
        private System.Windows.Forms.Button cmdAddSubject;
        private System.Windows.Forms.Button cmdAddSemester;
        private System.Windows.Forms.Button cmdRemoveSemester;
        private System.Windows.Forms.Button cmdAddYear;
        private System.Windows.Forms.Button cmdRemoveYear;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAbbreviation;
        private System.Windows.Forms.Label label5;
    }
}