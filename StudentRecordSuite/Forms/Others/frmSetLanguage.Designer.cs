namespace StudentRecordSuite
{
    partial class frmSetLanguage
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEnglish = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdJapanese = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose your prefered language.\r\nご希望の言語を選択してください。\r\nBonvolu elekti vian pref" +
    "eran lingvon.";
            // 
            // cmdEnglish
            // 
            this.cmdEnglish.Image = global::StudentRecordSuite.Properties.Resources.flag_blue;
            this.cmdEnglish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEnglish.Location = new System.Drawing.Point(12, 51);
            this.cmdEnglish.Name = "cmdEnglish";
            this.cmdEnglish.Size = new System.Drawing.Size(83, 23);
            this.cmdEnglish.TabIndex = 0;
            this.cmdEnglish.Text = "English";
            this.cmdEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEnglish.UseVisualStyleBackColor = true;
            this.cmdEnglish.Click += new System.EventHandler(this.cmdEnglish_Click);
            // 
            // button1
            // 
            this.button1.Image = global::StudentRecordSuite.Properties.Resources.flag_green;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(190, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Esperanto";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdJapanese
            // 
            this.cmdJapanese.Image = global::StudentRecordSuite.Properties.Resources.flag_red;
            this.cmdJapanese.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdJapanese.Location = new System.Drawing.Point(101, 51);
            this.cmdJapanese.Name = "cmdJapanese";
            this.cmdJapanese.Size = new System.Drawing.Size(83, 23);
            this.cmdJapanese.TabIndex = 1;
            this.cmdJapanese.Text = "日本語";
            this.cmdJapanese.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdJapanese.UseVisualStyleBackColor = true;
            this.cmdJapanese.Click += new System.EventHandler(this.cmdJapanese_Click);
            // 
            // frmSetLanguage
            // 
            this.AcceptButton = this.cmdEnglish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(361, 127);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdJapanese);
            this.Controls.Add(this.cmdEnglish);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmSetLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Language settings / 言語設定 / Lingvo-agordo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSetLanguage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEnglish;
        private System.Windows.Forms.Button cmdJapanese;
        private System.Windows.Forms.Button button1;
    }
}