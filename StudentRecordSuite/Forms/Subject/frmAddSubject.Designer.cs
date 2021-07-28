namespace StudentRecordSuite
{
    partial class frmAddSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSubject));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLecture = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLaboratory = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAcademic = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPre = new System.Windows.Forms.ComboBox();
            this.cmdRemovePre = new System.Windows.Forms.Button();
            this.cmdAddPre = new System.Windows.Forms.Button();
            this.lstPre = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCo = new System.Windows.Forms.ComboBox();
            this.cmdRemoveCo = new System.Windows.Forms.Button();
            this.cmdAddCo = new System.Windows.Forms.Button();
            this.lstCo = new System.Windows.Forms.ListBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtLecture
            // 
            resources.ApplyResources(this.txtLecture, "txtLecture");
            this.txtLecture.Name = "txtLecture";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtLaboratory
            // 
            resources.ApplyResources(this.txtLaboratory, "txtLaboratory");
            this.txtLaboratory.Name = "txtLaboratory";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // chkAcademic
            // 
            resources.ApplyResources(this.chkAcademic, "chkAcademic");
            this.chkAcademic.Checked = true;
            this.chkAcademic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAcademic.Name = "chkAcademic";
            this.chkAcademic.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPre);
            this.groupBox1.Controls.Add(this.cmdRemovePre);
            this.groupBox1.Controls.Add(this.cmdAddPre);
            this.groupBox1.Controls.Add(this.lstPre);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cboPre
            // 
            this.cboPre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboPre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPre.FormattingEnabled = true;
            resources.ApplyResources(this.cboPre, "cboPre");
            this.cboPre.Name = "cboPre";
            this.cboPre.Sorted = true;
            // 
            // cmdRemovePre
            // 
            resources.ApplyResources(this.cmdRemovePre, "cmdRemovePre");
            this.cmdRemovePre.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemovePre.Name = "cmdRemovePre";
            this.cmdRemovePre.UseVisualStyleBackColor = true;
            this.cmdRemovePre.Click += new System.EventHandler(this.cmdRemovePre_Click);
            // 
            // cmdAddPre
            // 
            this.cmdAddPre.Image = global::StudentRecordSuite.Properties.Resources.add;
            resources.ApplyResources(this.cmdAddPre, "cmdAddPre");
            this.cmdAddPre.Name = "cmdAddPre";
            this.cmdAddPre.UseVisualStyleBackColor = true;
            this.cmdAddPre.Click += new System.EventHandler(this.cmdAddPre_Click);
            // 
            // lstPre
            // 
            this.lstPre.FormattingEnabled = true;
            resources.ApplyResources(this.lstPre, "lstPre");
            this.lstPre.Name = "lstPre";
            this.lstPre.Sorted = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCo);
            this.groupBox2.Controls.Add(this.cmdRemoveCo);
            this.groupBox2.Controls.Add(this.cmdAddCo);
            this.groupBox2.Controls.Add(this.lstCo);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // cboCo
            // 
            this.cboCo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboCo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCo.FormattingEnabled = true;
            resources.ApplyResources(this.cboCo, "cboCo");
            this.cboCo.Name = "cboCo";
            this.cboCo.Sorted = true;
            // 
            // cmdRemoveCo
            // 
            resources.ApplyResources(this.cmdRemoveCo, "cmdRemoveCo");
            this.cmdRemoveCo.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemoveCo.Name = "cmdRemoveCo";
            this.cmdRemoveCo.UseVisualStyleBackColor = true;
            this.cmdRemoveCo.Click += new System.EventHandler(this.cmdRemoveCo_Click);
            // 
            // cmdAddCo
            // 
            this.cmdAddCo.Image = global::StudentRecordSuite.Properties.Resources.add;
            resources.ApplyResources(this.cmdAddCo, "cmdAddCo");
            this.cmdAddCo.Name = "cmdAddCo";
            this.cmdAddCo.UseVisualStyleBackColor = true;
            this.cmdAddCo.Click += new System.EventHandler(this.cmdAddCo_Click);
            // 
            // lstCo
            // 
            this.lstCo.FormattingEnabled = true;
            resources.ApplyResources(this.lstCo, "lstCo");
            this.lstCo.Name = "lstCo";
            this.lstCo.Sorted = true;
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
            // chkClose
            // 
            resources.ApplyResources(this.chkClose, "chkClose");
            this.chkClose.Name = "chkClose";
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtCode, "txtCode");
            this.txtCode.Name = "txtCode";
            // 
            // frmAddSubject
            // 
            this.AcceptButton = this.cmdSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAcademic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLaboratory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLecture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddSubject";
            this.Load += new System.EventHandler(this.frmAddSubject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtLecture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtLaboratory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAcademic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPre;
        private System.Windows.Forms.Button cmdRemovePre;
        private System.Windows.Forms.Button cmdAddPre;
        private System.Windows.Forms.ListBox lstPre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCo;
        private System.Windows.Forms.Button cmdRemoveCo;
        private System.Windows.Forms.Button cmdAddCo;
        private System.Windows.Forms.ListBox lstCo;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.TextBox txtCode;
    }
}