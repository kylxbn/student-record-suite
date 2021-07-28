namespace StudentRecordSuite
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDatabasePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.importGradesFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrollStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForAStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProfessorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditProfessorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeProfessorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.advanceAStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterGradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.softwareLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearchStudentNo = new System.Windows.Forms.MaskedTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblSearchResult = new System.Windows.Forms.Label();
            this.txtSearchLName = new System.Windows.Forms.TextBox();
            this.txtSearchFName = new System.Windows.Forms.TextBox();
            this.txtSearchCourse = new System.Windows.Forms.TextBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.mnuDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEnrolledSubjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.advanceStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterGradesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefresh = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmdResetSearch = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.mnuDGV.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripStatusLabel1,
            this.lblError});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            resources.ApplyResources(this.lblError, "lblError");
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programSettingsToolStripMenuItem,
            this.changeDatabasePasswordToolStripMenuItem,
            this.toolStripMenuItem1,
            this.importGradesFromExcelToolStripMenuItem,
            this.backupDatabaseToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // programSettingsToolStripMenuItem
            // 
            this.programSettingsToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.cog;
            this.programSettingsToolStripMenuItem.Name = "programSettingsToolStripMenuItem";
            resources.ApplyResources(this.programSettingsToolStripMenuItem, "programSettingsToolStripMenuItem");
            this.programSettingsToolStripMenuItem.Click += new System.EventHandler(this.programSettingsToolStripMenuItem_Click);
            // 
            // changeDatabasePasswordToolStripMenuItem
            // 
            this.changeDatabasePasswordToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.key;
            this.changeDatabasePasswordToolStripMenuItem.Name = "changeDatabasePasswordToolStripMenuItem";
            resources.ApplyResources(this.changeDatabasePasswordToolStripMenuItem, "changeDatabasePasswordToolStripMenuItem");
            this.changeDatabasePasswordToolStripMenuItem.Click += new System.EventHandler(this.changeDatabasePasswordToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // importGradesFromExcelToolStripMenuItem
            // 
            this.importGradesFromExcelToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.basket_put;
            this.importGradesFromExcelToolStripMenuItem.Name = "importGradesFromExcelToolStripMenuItem";
            resources.ApplyResources(this.importGradesFromExcelToolStripMenuItem, "importGradesFromExcelToolStripMenuItem");
            this.importGradesFromExcelToolStripMenuItem.Click += new System.EventHandler(this.importGradesFromExcelToolStripMenuItem_Click);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.disk;
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            resources.ApplyResources(this.backupDatabaseToolStripMenuItem, "backupDatabaseToolStripMenuItem");
            this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem,
            this.subjectsToolStripMenuItem,
            this.coursesToolStripMenuItem,
            this.professorsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.advanceAStudentToolStripMenuItem,
            this.enterGradesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enrollStudentToolStripMenuItem,
            this.searchForAStudentToolStripMenuItem,
            this.removeStudentToolStripMenuItem});
            this.studentsToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.group;
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            resources.ApplyResources(this.studentsToolStripMenuItem, "studentsToolStripMenuItem");
            // 
            // enrollStudentToolStripMenuItem
            // 
            this.enrollStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.group_add;
            this.enrollStudentToolStripMenuItem.Name = "enrollStudentToolStripMenuItem";
            resources.ApplyResources(this.enrollStudentToolStripMenuItem, "enrollStudentToolStripMenuItem");
            this.enrollStudentToolStripMenuItem.Click += new System.EventHandler(this.enrollStudentToolStripMenuItem_Click);
            // 
            // searchForAStudentToolStripMenuItem
            // 
            this.searchForAStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.group_edit;
            this.searchForAStudentToolStripMenuItem.Name = "searchForAStudentToolStripMenuItem";
            resources.ApplyResources(this.searchForAStudentToolStripMenuItem, "searchForAStudentToolStripMenuItem");
            this.searchForAStudentToolStripMenuItem.Click += new System.EventHandler(this.searchForAStudentToolStripMenuItem_Click);
            // 
            // removeStudentToolStripMenuItem
            // 
            this.removeStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.group_delete;
            this.removeStudentToolStripMenuItem.Name = "removeStudentToolStripMenuItem";
            resources.ApplyResources(this.removeStudentToolStripMenuItem, "removeStudentToolStripMenuItem");
            this.removeStudentToolStripMenuItem.Click += new System.EventHandler(this.removeStudentToolStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSubjectToolStripMenuItem,
            this.viewEditSubjectToolStripMenuItem,
            this.removeSubjectToolStripMenuItem});
            this.subjectsToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.brick;
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            resources.ApplyResources(this.subjectsToolStripMenuItem, "subjectsToolStripMenuItem");
            // 
            // addSubjectToolStripMenuItem
            // 
            this.addSubjectToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.brick_add;
            this.addSubjectToolStripMenuItem.Name = "addSubjectToolStripMenuItem";
            resources.ApplyResources(this.addSubjectToolStripMenuItem, "addSubjectToolStripMenuItem");
            this.addSubjectToolStripMenuItem.Click += new System.EventHandler(this.addSubjectToolStripMenuItem_Click);
            // 
            // viewEditSubjectToolStripMenuItem
            // 
            this.viewEditSubjectToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.brick_edit;
            this.viewEditSubjectToolStripMenuItem.Name = "viewEditSubjectToolStripMenuItem";
            resources.ApplyResources(this.viewEditSubjectToolStripMenuItem, "viewEditSubjectToolStripMenuItem");
            this.viewEditSubjectToolStripMenuItem.Click += new System.EventHandler(this.viewEditSubjectToolStripMenuItem_Click);
            // 
            // removeSubjectToolStripMenuItem
            // 
            this.removeSubjectToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.brick_delete;
            this.removeSubjectToolStripMenuItem.Name = "removeSubjectToolStripMenuItem";
            resources.ApplyResources(this.removeSubjectToolStripMenuItem, "removeSubjectToolStripMenuItem");
            this.removeSubjectToolStripMenuItem.Click += new System.EventHandler(this.removeSubjectToolStripMenuItem_Click);
            // 
            // coursesToolStripMenuItem
            // 
            this.coursesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCourseToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.removeCourseToolStripMenuItem});
            this.coursesToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.book;
            this.coursesToolStripMenuItem.Name = "coursesToolStripMenuItem";
            resources.ApplyResources(this.coursesToolStripMenuItem, "coursesToolStripMenuItem");
            this.coursesToolStripMenuItem.Click += new System.EventHandler(this.coursesToolStripMenuItem_Click);
            // 
            // addCourseToolStripMenuItem
            // 
            this.addCourseToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.book_add;
            this.addCourseToolStripMenuItem.Name = "addCourseToolStripMenuItem";
            resources.ApplyResources(this.addCourseToolStripMenuItem, "addCourseToolStripMenuItem");
            this.addCourseToolStripMenuItem.Click += new System.EventHandler(this.addCourseToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.book_edit;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // removeCourseToolStripMenuItem
            // 
            this.removeCourseToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.book_delete;
            this.removeCourseToolStripMenuItem.Name = "removeCourseToolStripMenuItem";
            resources.ApplyResources(this.removeCourseToolStripMenuItem, "removeCourseToolStripMenuItem");
            this.removeCourseToolStripMenuItem.Click += new System.EventHandler(this.removeCourseToolStripMenuItem_Click);
            // 
            // professorsToolStripMenuItem
            // 
            this.professorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProfessorToolStripMenuItem,
            this.viewEditProfessorToolStripMenuItem,
            this.removeProfessorToolStripMenuItem});
            resources.ApplyResources(this.professorsToolStripMenuItem, "professorsToolStripMenuItem");
            this.professorsToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.user;
            this.professorsToolStripMenuItem.Name = "professorsToolStripMenuItem";
            // 
            // addProfessorToolStripMenuItem
            // 
            this.addProfessorToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.user_add;
            this.addProfessorToolStripMenuItem.Name = "addProfessorToolStripMenuItem";
            resources.ApplyResources(this.addProfessorToolStripMenuItem, "addProfessorToolStripMenuItem");
            // 
            // viewEditProfessorToolStripMenuItem
            // 
            this.viewEditProfessorToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.user_edit;
            this.viewEditProfessorToolStripMenuItem.Name = "viewEditProfessorToolStripMenuItem";
            resources.ApplyResources(this.viewEditProfessorToolStripMenuItem, "viewEditProfessorToolStripMenuItem");
            // 
            // removeProfessorToolStripMenuItem
            // 
            this.removeProfessorToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.user_delete;
            this.removeProfessorToolStripMenuItem.Name = "removeProfessorToolStripMenuItem";
            resources.ApplyResources(this.removeProfessorToolStripMenuItem, "removeProfessorToolStripMenuItem");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // advanceAStudentToolStripMenuItem
            // 
            this.advanceAStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.add;
            this.advanceAStudentToolStripMenuItem.Name = "advanceAStudentToolStripMenuItem";
            resources.ApplyResources(this.advanceAStudentToolStripMenuItem, "advanceAStudentToolStripMenuItem");
            this.advanceAStudentToolStripMenuItem.Click += new System.EventHandler(this.advanceAStudentToolStripMenuItem_Click);
            // 
            // enterGradesToolStripMenuItem
            // 
            this.enterGradesToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.accept;
            this.enterGradesToolStripMenuItem.Name = "enterGradesToolStripMenuItem";
            resources.ApplyResources(this.enterGradesToolStripMenuItem, "enterGradesToolStripMenuItem");
            this.enterGradesToolStripMenuItem.Click += new System.EventHandler(this.enterGradesToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tORToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            resources.ApplyResources(this.generateToolStripMenuItem, "generateToolStripMenuItem");
            // 
            // tORToolStripMenuItem
            // 
            this.tORToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.printer;
            this.tORToolStripMenuItem.Name = "tORToolStripMenuItem";
            resources.ApplyResources(this.tORToolStripMenuItem, "tORToolStripMenuItem");
            this.tORToolStripMenuItem.Click += new System.EventHandler(this.tORToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem2,
            this.softwareLicenseToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = global::StudentRecordSuite.Properties.Resources.help;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            resources.ApplyResources(this.helpToolStripMenuItem1, "helpToolStripMenuItem1");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.information;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // softwareLicenseToolStripMenuItem
            // 
            this.softwareLicenseToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.key;
            this.softwareLicenseToolStripMenuItem.Name = "softwareLicenseToolStripMenuItem";
            resources.ApplyResources(this.softwareLicenseToolStripMenuItem, "softwareLicenseToolStripMenuItem");
            this.softwareLicenseToolStripMenuItem.Click += new System.EventHandler(this.softwareLicenseToolStripMenuItem_Click);
            // 
            // txtSearchStudentNo
            // 
            resources.ApplyResources(this.txtSearchStudentNo, "txtSearchStudentNo");
            this.txtSearchStudentNo.Name = "txtSearchStudentNo";
            this.txtSearchStudentNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtSearchStudentNo.TextChanged += new System.EventHandler(this.txtStudentID_TextChanged);
            this.txtSearchStudentNo.Enter += new System.EventHandler(this.txtStudentID_Enter);
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblSearchResult
            // 
            resources.ApplyResources(this.lblSearchResult, "lblSearchResult");
            this.lblSearchResult.ForeColor = System.Drawing.Color.Red;
            this.lblSearchResult.Name = "lblSearchResult";
            // 
            // txtSearchLName
            // 
            this.txtSearchLName.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.txtSearchLName, "txtSearchLName");
            this.txtSearchLName.Name = "txtSearchLName";
            this.txtSearchLName.TextChanged += new System.EventHandler(this.txtSearchLName_TextChanged);
            this.txtSearchLName.Enter += new System.EventHandler(this.txtSearchLName_Enter);
            this.txtSearchLName.Leave += new System.EventHandler(this.txtSearchLName_Leave);
            // 
            // txtSearchFName
            // 
            this.txtSearchFName.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.txtSearchFName, "txtSearchFName");
            this.txtSearchFName.Name = "txtSearchFName";
            this.txtSearchFName.TextChanged += new System.EventHandler(this.txtSearchFName_TextChanged);
            this.txtSearchFName.Enter += new System.EventHandler(this.txtSearchFName_Enter);
            this.txtSearchFName.Leave += new System.EventHandler(this.txtSearchFName_Leave);
            // 
            // txtSearchCourse
            // 
            this.txtSearchCourse.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.txtSearchCourse, "txtSearchCourse");
            this.txtSearchCourse.Name = "txtSearchCourse";
            this.txtSearchCourse.TextChanged += new System.EventHandler(this.txtSearchCourse_TextChanged);
            this.txtSearchCourse.Enter += new System.EventHandler(this.txtSearchCourse_Enter);
            this.txtSearchCourse.Leave += new System.EventHandler(this.txtSearchCourse_Leave);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.ContextMenuStrip = this.mnuDGV;
            resources.ApplyResources(this.dgvResults, "dgvResults");
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // mnuDGV
            // 
            this.mnuDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentToolStripMenuItem,
            this.editStudentToolStripMenuItem,
            this.deleteStudentToolStripMenuItem,
            this.viewEnrolledSubjectsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.advanceStudentToolStripMenuItem,
            this.enterGradesToolStripMenuItem1});
            this.mnuDGV.Name = "mnuDGV";
            resources.ApplyResources(this.mnuDGV, "mnuDGV");
            this.mnuDGV.Opening += new System.ComponentModel.CancelEventHandler(this.mnuDGV_Opening);
            // 
            // addStudentToolStripMenuItem
            // 
            this.addStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.group_add;
            this.addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem";
            resources.ApplyResources(this.addStudentToolStripMenuItem, "addStudentToolStripMenuItem");
            this.addStudentToolStripMenuItem.Click += new System.EventHandler(this.addStudentToolStripMenuItem_Click);
            // 
            // editStudentToolStripMenuItem
            // 
            this.editStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.group_edit;
            this.editStudentToolStripMenuItem.Name = "editStudentToolStripMenuItem";
            resources.ApplyResources(this.editStudentToolStripMenuItem, "editStudentToolStripMenuItem");
            this.editStudentToolStripMenuItem.Click += new System.EventHandler(this.editStudentToolStripMenuItem_Click);
            // 
            // deleteStudentToolStripMenuItem
            // 
            this.deleteStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.group_delete;
            this.deleteStudentToolStripMenuItem.Name = "deleteStudentToolStripMenuItem";
            resources.ApplyResources(this.deleteStudentToolStripMenuItem, "deleteStudentToolStripMenuItem");
            this.deleteStudentToolStripMenuItem.Click += new System.EventHandler(this.deleteStudentToolStripMenuItem_Click);
            // 
            // viewEnrolledSubjectsToolStripMenuItem
            // 
            this.viewEnrolledSubjectsToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.book;
            this.viewEnrolledSubjectsToolStripMenuItem.Name = "viewEnrolledSubjectsToolStripMenuItem";
            resources.ApplyResources(this.viewEnrolledSubjectsToolStripMenuItem, "viewEnrolledSubjectsToolStripMenuItem");
            this.viewEnrolledSubjectsToolStripMenuItem.Click += new System.EventHandler(this.viewEnrolledSubjectsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // advanceStudentToolStripMenuItem
            // 
            this.advanceStudentToolStripMenuItem.Image = global::StudentRecordSuite.Properties.Resources.add;
            this.advanceStudentToolStripMenuItem.Name = "advanceStudentToolStripMenuItem";
            resources.ApplyResources(this.advanceStudentToolStripMenuItem, "advanceStudentToolStripMenuItem");
            this.advanceStudentToolStripMenuItem.Click += new System.EventHandler(this.advanceStudentToolStripMenuItem_Click);
            // 
            // enterGradesToolStripMenuItem1
            // 
            this.enterGradesToolStripMenuItem1.Image = global::StudentRecordSuite.Properties.Resources.accept;
            this.enterGradesToolStripMenuItem1.Name = "enterGradesToolStripMenuItem1";
            resources.ApplyResources(this.enterGradesToolStripMenuItem1, "enterGradesToolStripMenuItem1");
            this.enterGradesToolStripMenuItem1.Click += new System.EventHandler(this.enterGradesToolStripMenuItem1_Click);
            // 
            // autoRefresh
            // 
            this.autoRefresh.Enabled = true;
            this.autoRefresh.Interval = 1000;
            this.autoRefresh.Tick += new System.EventHandler(this.autoRefresh_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Image = global::StudentRecordSuite.Properties.Resources.group;
            this.label1.Name = "label1";
            // 
            // cmdResetSearch
            // 
            this.cmdResetSearch.Image = global::StudentRecordSuite.Properties.Resources.cancel;
            resources.ApplyResources(this.cmdResetSearch, "cmdResetSearch");
            this.cmdResetSearch.Name = "cmdResetSearch";
            this.cmdResetSearch.UseVisualStyleBackColor = true;
            this.cmdResetSearch.Click += new System.EventHandler(this.cmdResetSearch_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdResetSearch);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.txtSearchCourse);
            this.Controls.Add(this.txtSearchFName);
            this.Controls.Add(this.txtSearchLName);
            this.Controls.Add(this.lblSearchResult);
            this.Controls.Add(this.txtSearchStudentNo);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.mnuDGV.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem softwareLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem advanceAStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem professorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enrollStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForAStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProfessorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditProfessorToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox txtSearchStudentNo;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
        private System.Windows.Forms.Label lblSearchResult;
        private System.Windows.Forms.ToolStripMenuItem removeStudentToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearchLName;
        private System.Windows.Forms.TextBox txtSearchFName;
        private System.Windows.Forms.TextBox txtSearchCourse;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button cmdResetSearch;
        private System.Windows.Forms.ContextMenuStrip mnuDGV;
        private System.Windows.Forms.ToolStripMenuItem addStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advanceStudentToolStripMenuItem;
        private System.Windows.Forms.Timer autoRefresh;
        private System.Windows.Forms.ToolStripMenuItem removeSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeProfessorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterGradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem enterGradesToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem importGradesFromExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem viewEnrolledSubjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDatabasePasswordToolStripMenuItem;
    }
}

