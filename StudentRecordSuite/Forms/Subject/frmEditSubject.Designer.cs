namespace StudentRecordSuite
{
    partial class frmEditSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditSubject));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCo = new System.Windows.Forms.ComboBox();
            this.cmdRemoveCo = new System.Windows.Forms.Button();
            this.cmdAddCo = new System.Windows.Forms.Button();
            this.lstCo = new System.Windows.Forms.ListBox();
            this.cboPre = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdRemovePre = new System.Windows.Forms.Button();
            this.cmdAddPre = new System.Windows.Forms.Button();
            this.lstPre = new System.Windows.Forms.ListBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkAcademic = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLaboratory = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLecture = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSubjects = new System.Windows.Forms.ListBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCo);
            this.groupBox2.Controls.Add(this.cmdRemoveCo);
            this.groupBox2.Controls.Add(this.cmdAddCo);
            this.groupBox2.Controls.Add(this.lstCo);
            this.groupBox2.Location = new System.Drawing.Point(450, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 238);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Corequisites";
            // 
            // cboCo
            // 
            this.cboCo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboCo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCo.FormattingEnabled = true;
            this.cboCo.Location = new System.Drawing.Point(6, 182);
            this.cboCo.Name = "cboCo";
            this.cboCo.Size = new System.Drawing.Size(225, 21);
            this.cboCo.Sorted = true;
            this.cboCo.TabIndex = 11;
            // 
            // cmdRemoveCo
            // 
            this.cmdRemoveCo.Enabled = false;
            this.cmdRemoveCo.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemoveCo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemoveCo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdRemoveCo.Location = new System.Drawing.Point(128, 209);
            this.cmdRemoveCo.Name = "cmdRemoveCo";
            this.cmdRemoveCo.Size = new System.Drawing.Size(103, 23);
            this.cmdRemoveCo.TabIndex = 13;
            this.cmdRemoveCo.Text = "Remove";
            this.cmdRemoveCo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemoveCo.UseVisualStyleBackColor = true;
            this.cmdRemoveCo.Click += new System.EventHandler(this.cmdRemoveCo_Click);
            // 
            // cmdAddCo
            // 
            this.cmdAddCo.Image = global::StudentRecordSuite.Properties.Resources.add;
            this.cmdAddCo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddCo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdAddCo.Location = new System.Drawing.Point(6, 209);
            this.cmdAddCo.Name = "cmdAddCo";
            this.cmdAddCo.Size = new System.Drawing.Size(105, 23);
            this.cmdAddCo.TabIndex = 12;
            this.cmdAddCo.Text = "Add";
            this.cmdAddCo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAddCo.UseVisualStyleBackColor = true;
            this.cmdAddCo.Click += new System.EventHandler(this.cmdAddCo_Click);
            // 
            // lstCo
            // 
            this.lstCo.FormattingEnabled = true;
            this.lstCo.Location = new System.Drawing.Point(6, 19);
            this.lstCo.Name = "lstCo";
            this.lstCo.Size = new System.Drawing.Size(225, 160);
            this.lstCo.Sorted = true;
            this.lstCo.TabIndex = 10;
            // 
            // cboPre
            // 
            this.cboPre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboPre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPre.FormattingEnabled = true;
            this.cboPre.Location = new System.Drawing.Point(6, 182);
            this.cboPre.Name = "cboPre";
            this.cboPre.Size = new System.Drawing.Size(213, 21);
            this.cboPre.Sorted = true;
            this.cboPre.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPre);
            this.groupBox1.Controls.Add(this.cmdRemovePre);
            this.groupBox1.Controls.Add(this.cmdAddPre);
            this.groupBox1.Controls.Add(this.lstPre);
            this.groupBox1.Location = new System.Drawing.Point(219, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 238);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prerequisutes";
            // 
            // cmdRemovePre
            // 
            this.cmdRemovePre.Enabled = false;
            this.cmdRemovePre.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemovePre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemovePre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdRemovePre.Location = new System.Drawing.Point(123, 209);
            this.cmdRemovePre.Name = "cmdRemovePre";
            this.cmdRemovePre.Size = new System.Drawing.Size(96, 23);
            this.cmdRemovePre.TabIndex = 9;
            this.cmdRemovePre.Text = "Remove";
            this.cmdRemovePre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemovePre.UseVisualStyleBackColor = true;
            this.cmdRemovePre.Click += new System.EventHandler(this.cmdRemovePre_Click);
            // 
            // cmdAddPre
            // 
            this.cmdAddPre.Image = global::StudentRecordSuite.Properties.Resources.add;
            this.cmdAddPre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddPre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdAddPre.Location = new System.Drawing.Point(7, 209);
            this.cmdAddPre.Name = "cmdAddPre";
            this.cmdAddPre.Size = new System.Drawing.Size(96, 23);
            this.cmdAddPre.TabIndex = 8;
            this.cmdAddPre.Text = "Add";
            this.cmdAddPre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAddPre.UseVisualStyleBackColor = true;
            this.cmdAddPre.Click += new System.EventHandler(this.cmdAddPre_Click);
            // 
            // lstPre
            // 
            this.lstPre.FormattingEnabled = true;
            this.lstPre.Location = new System.Drawing.Point(6, 19);
            this.lstPre.Name = "lstPre";
            this.lstPre.Size = new System.Drawing.Size(213, 160);
            this.lstPre.Sorted = true;
            this.lstPre.TabIndex = 6;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdCancel.Location = new System.Drawing.Point(531, 377);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkAcademic
            // 
            this.chkAcademic.AutoSize = true;
            this.chkAcademic.Checked = true;
            this.chkAcademic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAcademic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkAcademic.Location = new System.Drawing.Point(307, 110);
            this.chkAcademic.Name = "chkAcademic";
            this.chkAcademic.Size = new System.Drawing.Size(89, 17);
            this.chkAcademic.TabIndex = 5;
            this.chkAcademic.Text = "Major subject";
            this.chkAcademic.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(216, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Laboratory units:";
            // 
            // txtLaboratory
            // 
            this.txtLaboratory.Location = new System.Drawing.Point(307, 84);
            this.txtLaboratory.Name = "txtLaboratory";
            this.txtLaboratory.Size = new System.Drawing.Size(380, 20);
            this.txtLaboratory.TabIndex = 4;
            this.txtLaboratory.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtLaboratory_MaskInputRejected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(216, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Lecture units:";
            // 
            // txtLecture
            // 
            this.txtLecture.Location = new System.Drawing.Point(307, 58);
            this.txtLecture.Name = "txtLecture";
            this.txtLecture.Size = new System.Drawing.Size(380, 20);
            this.txtLecture.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(216, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Subject name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Subject code:";
            // 
            // lstSubjects
            // 
            this.lstSubjects.FormattingEnabled = true;
            this.lstSubjects.Location = new System.Drawing.Point(12, 12);
            this.lstSubjects.Name = "lstSubjects";
            this.lstSubjects.Size = new System.Drawing.Size(198, 381);
            this.lstSubjects.Sorted = true;
            this.lstSubjects.TabIndex = 0;
            this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(307, 6);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(380, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(307, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(380, 20);
            this.txtName.TabIndex = 2;
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Enabled = false;
            this.cmdSubmit.Image = global::StudentRecordSuite.Properties.Resources.disk;
            this.cmdSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSubmit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSubmit.Location = new System.Drawing.Point(612, 377);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 23);
            this.cmdSubmit.TabIndex = 15;
            this.cmdSubmit.Text = "Save";
            this.cmdSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // frmEditSubject
            // 
            this.AcceptButton = this.cmdSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(699, 447);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lstSubjects);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.chkAcademic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLaboratory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLecture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditSubject";
            this.Text = "View / Edit Subject";
            this.Load += new System.EventHandler(this.frmEditSubject_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCo;
        private System.Windows.Forms.Button cmdRemoveCo;
        private System.Windows.Forms.Button cmdAddCo;
        private System.Windows.Forms.ListBox lstCo;
        private System.Windows.Forms.ComboBox cboPre;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdRemovePre;
        private System.Windows.Forms.Button cmdAddPre;
        private System.Windows.Forms.ListBox lstPre;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkAcademic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtLaboratory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtLecture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSubjects;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
    }
}