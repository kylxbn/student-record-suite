namespace StudentRecordSuite
{
    partial class frmEnrollStudent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnrollStudent));
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUnits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstEnrolled = new System.Windows.Forms.ListBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBecome = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRegular = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdAddAll = new System.Windows.Forms.Button();
            this.cmdRemoveAll = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.chkForceEnroll = new System.Windows.Forms.CheckBox();
            this.chkAllowIrregular = new System.Windows.Forms.CheckBox();
            this.chkIgnoreRequisite = new System.Windows.Forms.CheckBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCourse
            // 
            this.txtCourse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCourse.Location = new System.Drawing.Point(79, 13);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(63, 20);
            this.txtCourse.TabIndex = 0;
            this.txtCourse.TextChanged += new System.EventHandler(this.txtCourse_TextChanged);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(148, 13);
            this.txtNumber.Mask = "00-0000";
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(58, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNumber.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtNumber_MaskInputRejected);
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student No.:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(212, 16);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(63, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Not found";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstAvailable);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 310);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available subjects";
            // 
            // lstAvailable
            // 
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.Location = new System.Drawing.Point(6, 19);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(210, 277);
            this.lstAvailable.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUnits);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lstEnrolled);
            this.groupBox2.Location = new System.Drawing.Point(269, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 310);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subjects to enroll";
            // 
            // txtUnits
            // 
            this.txtUnits.AutoSize = true;
            this.txtUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnits.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtUnits.Location = new System.Drawing.Point(71, 22);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(41, 13);
            this.txtUnits.TabIndex = 5;
            this.txtUnits.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total units:";
            // 
            // lstEnrolled
            // 
            this.lstEnrolled.FormattingEnabled = true;
            this.lstEnrolled.Location = new System.Drawing.Point(6, 45);
            this.lstEnrolled.Name = "lstEnrolled";
            this.lstEnrolled.Size = new System.Drawing.Size(210, 251);
            this.lstEnrolled.TabIndex = 8;
            // 
            // timer
            // 
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBecome);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblRegular);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtCourse);
            this.groupBox3.Controls.Add(this.txtNumber);
            this.groupBox3.Controls.Add(this.lblResult);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(479, 73);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search student";
            // 
            // lblBecome
            // 
            this.lblBecome.AutoSize = true;
            this.lblBecome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBecome.Location = new System.Drawing.Point(357, 42);
            this.lblBecome.Name = "lblBecome";
            this.lblBecome.Size = new System.Drawing.Size(41, 13);
            this.lblBecome.TabIndex = 9;
            this.lblBecome.Text = "label6";
            this.lblBecome.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Will become:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Now:";
            // 
            // lblRegular
            // 
            this.lblRegular.AutoSize = true;
            this.lblRegular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegular.Location = new System.Drawing.Point(357, 16);
            this.lblRegular.Name = "lblRegular";
            this.lblRegular.Size = new System.Drawing.Size(41, 13);
            this.lblRegular.TabIndex = 6;
            this.lblRegular.Text = "label4";
            this.lblRegular.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(79, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 20);
            this.txtName.TabIndex = 2;
            // 
            // cmdAddAll
            // 
            this.cmdAddAll.Image = global::StudentRecordSuite.Properties.Resources.basket_put;
            this.cmdAddAll.Location = new System.Drawing.Point(240, 149);
            this.cmdAddAll.Name = "cmdAddAll";
            this.cmdAddAll.Size = new System.Drawing.Size(23, 23);
            this.cmdAddAll.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdAddAll, "Automatically adds subjects available to the enroll list.");
            this.cmdAddAll.UseVisualStyleBackColor = true;
            this.cmdAddAll.Click += new System.EventHandler(this.cmdAddAll_Click);
            // 
            // cmdRemoveAll
            // 
            this.cmdRemoveAll.Image = global::StudentRecordSuite.Properties.Resources.basket_remove;
            this.cmdRemoveAll.Location = new System.Drawing.Point(240, 178);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(23, 23);
            this.cmdRemoveAll.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cmdRemoveAll, "Remove all subjects on the enroll list");
            this.cmdRemoveAll.UseVisualStyleBackColor = true;
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Image = global::StudentRecordSuite.Properties.Resources.arrow_left;
            this.cmdRemove.Location = new System.Drawing.Point(240, 120);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(23, 23);
            this.cmdRemove.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdRemove, "Remove selected subject from the enroll list");
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = global::StudentRecordSuite.Properties.Resources.arrow_right;
            this.cmdAdd.Location = new System.Drawing.Point(240, 91);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(23, 23);
            this.cmdAdd.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdAdd, "Add selected subject to the enroll list.");
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // chkForceEnroll
            // 
            this.chkForceEnroll.AutoSize = true;
            this.chkForceEnroll.Location = new System.Drawing.Point(12, 411);
            this.chkForceEnroll.Name = "chkForceEnroll";
            this.chkForceEnroll.Size = new System.Drawing.Size(81, 17);
            this.chkForceEnroll.TabIndex = 9;
            this.chkForceEnroll.Text = "Force enroll";
            this.chkForceEnroll.UseVisualStyleBackColor = true;
            // 
            // chkAllowIrregular
            // 
            this.chkAllowIrregular.AutoSize = true;
            this.chkAllowIrregular.Location = new System.Drawing.Point(12, 434);
            this.chkAllowIrregular.Name = "chkAllowIrregular";
            this.chkAllowIrregular.Size = new System.Drawing.Size(129, 17);
            this.chkAllowIrregular.TabIndex = 10;
            this.chkAllowIrregular.Text = "Allow irregular student";
            this.chkAllowIrregular.UseVisualStyleBackColor = true;
            this.chkAllowIrregular.CheckedChanged += new System.EventHandler(this.chkAllowIrregular_CheckedChanged);
            // 
            // chkIgnoreRequisite
            // 
            this.chkIgnoreRequisite.AutoSize = true;
            this.chkIgnoreRequisite.Location = new System.Drawing.Point(12, 457);
            this.chkIgnoreRequisite.Name = "chkIgnoreRequisite";
            this.chkIgnoreRequisite.Size = new System.Drawing.Size(179, 17);
            this.chkIgnoreRequisite.TabIndex = 11;
            this.chkIgnoreRequisite.Text = "Ignore prerequisites/corequisites";
            this.chkIgnoreRequisite.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Image = global::StudentRecordSuite.Properties.Resources.add;
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(416, 433);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "OK";
            this.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(335, 434);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Location = new System.Drawing.Point(291, 407);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Date of enrollment:";
            // 
            // frmEnrollStudent
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(592, 491);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.chkIgnoreRequisite);
            this.Controls.Add(this.chkAllowIrregular);
            this.Controls.Add(this.chkForceEnroll);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdAddAll);
            this.Controls.Add(this.cmdRemoveAll);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEnrollStudent";
            this.Text = "Enroll Student";
            this.Load += new System.EventHandler(this.frmEnrollStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.MaskedTextBox txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstEnrolled;
        private System.Windows.Forms.Button cmdAddAll;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdRemoveAll;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtUnits;
        private System.Windows.Forms.Label lblRegular;
        private System.Windows.Forms.CheckBox chkForceEnroll;
        private System.Windows.Forms.CheckBox chkAllowIrregular;
        private System.Windows.Forms.CheckBox chkIgnoreRequisite;
        private System.Windows.Forms.Label lblBecome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label6;
    }
}