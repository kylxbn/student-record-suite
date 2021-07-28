namespace StudentRecordSuite
{
    partial class frmRemoveStudent
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentNumber = new System.Windows.Forms.MaskedTextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkSure = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.txtStudentCourse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student ID:";
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Location = new System.Drawing.Point(181, 12);
            this.txtStudentNumber.Mask = "00-0000";
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(54, 20);
            this.txtStudentNumber.TabIndex = 1;
            this.txtStudentNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtStudentNumber.TextChanged += new System.EventHandler(this.txtStudentNumber_TextChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(148, 64);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkSure
            // 
            this.chkSure.AutoSize = true;
            this.chkSure.Location = new System.Drawing.Point(15, 68);
            this.chkSure.Name = "chkSure";
            this.chkSure.Size = new System.Drawing.Size(62, 17);
            this.chkSure.TabIndex = 2;
            this.chkSure.TabStop = false;
            this.chkSure.Text = "I\'m sure";
            this.chkSure.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(241, 15);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(63, 13);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "Not found";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(100, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 13);
            this.txtName.TabIndex = 9;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Image = global::StudentRecordSuite.Properties.Resources.delete;
            this.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemove.Location = new System.Drawing.Point(229, 64);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 4;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // txtStudentCourse
            // 
            this.txtStudentCourse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStudentCourse.Location = new System.Drawing.Point(79, 12);
            this.txtStudentCourse.Name = "txtStudentCourse";
            this.txtStudentCourse.Size = new System.Drawing.Size(96, 20);
            this.txtStudentCourse.TabIndex = 0;
            this.txtStudentCourse.TextChanged += new System.EventHandler(this.txtStudentNumber_TextChanged);
            // 
            // frmRemoveStudent
            // 
            this.AcceptButton = this.cmdRemove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(365, 148);
            this.ControlBox = false;
            this.Controls.Add(this.txtStudentCourse);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkSure);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtStudentNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRemove);
            this.Name = "frmRemoveStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove student";
            this.Load += new System.EventHandler(this.frmRemoveStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtStudentNumber;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkSure;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.TextBox txtStudentCourse;
    }
}