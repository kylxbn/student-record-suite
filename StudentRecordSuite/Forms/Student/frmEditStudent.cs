using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentRecordSuite
{
    public partial class frmEditStudent : Form
    {
        bool cleared = true;

        public frmEditStudent(string ID = "")
        {
            InitializeComponent();
            if (ID != "")
            {
                ID = ID.Replace("-", "");
                txtSearchStudentNo.Text = ID.Substring(ID.Length - 6, 6);
                txtSearchCourse.Text = ID.Substring(0, ID.Length - 6);
            }
        }

        private void txtSearchCourse_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void txtSearchStudentNo_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            DataTable dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Student_Data WHERE StudentCourse = '{0}' AND StudentNumber = '{1}';", txtSearchCourse.Text.Trim(), txtSearchStudentNo.Text));
            if (dt.Rows.Count == 0)
            {
                ClearFields();
                lblSearchResult.Text = "No records found";
                return;
            }
            DataRow dr = dt.Rows[0];
            txtStudentNo.Text = dr["StudentNumber"].ToString();
            txtStudentSurname.Text = dr["LName"].ToString();
            txtStudentFirstName.Text = dr["FName"].ToString();
            txtStudentMiddleName.Text = dr["MName"].ToString();
            cboCourse.Text = dr["StudentCourse"].ToString();
            if (dr["Year"].ToString() == "0")
            {
                if (dr["Semester"].ToString() == "0")
                {
                    // new studentzh
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    txtYear.Text = "";
                    txtSemester.Text = "";
                    txtYear.Enabled = false;
                    txtSemester.Enabled = false;
                    label19.Enabled = false;
                    label21.Enabled = false;
                }
                else if (dr["Semester"].ToString() == "1")
                {
                    // irregular
                    radioButton1.Checked = false;
                    radioButton2.Checked =false;
                    radioButton3.Checked = true;
                    radioButton4.Checked = false;
                    txtYear.Text = "";
                    txtSemester.Text = "";
                    txtYear.Enabled = false;
                    txtSemester.Enabled = false;
                    label19.Enabled = false;
                    label21.Enabled = false;
                }
                else if (dr["Semester"].ToString() == "2")
                {
                    // graduated
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = true;
                    txtYear.Text = "";
                    txtSemester.Text = "";
                    txtYear.Enabled = false;
                    txtSemester.Enabled = false;
                    label19.Enabled = false;
                    label21.Enabled = false;
                }
                else
                {
                    // invalid data
                    MessageBox.Show(UIStrings.L.INVALID_DATA, UIStrings.L.INVALID_DATA_YEAR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                    txtYear.Enabled = true;
                    txtSemester.Enabled = true;
                    label19.Enabled = true;
                    label21.Enabled = true;
                }
            }
            else
            {
                // regular or transferee
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                radioButton3.Checked = false;
                txtYear.Enabled = true;
                txtSemester.Enabled = true;
                label19.Enabled = true;
                label21.Enabled = true;
            }
            txtYear.Text = dr["Year"].ToString();
            txtSemester.Text = dr["Semester"].ToString();
            txtSection.Text = dr["Section"].ToString();
            if (dr["IsMale"].ToString() == "1")
                optMale.Checked = true;
            else if (dr["IsMale"].ToString() == "0")
                optFemale.Checked = true;
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.Text = dr["DOB"].ToString();
            dtpDOB.Format = DateTimePickerFormat.Long;
            txtPOB.Text = dr["POB"].ToString();
            txtNationality.Text = dr["Nationality"].ToString();
            txtReligion.Text = dr["Religion"].ToString();
            if (dr["IsMarried"].ToString() == "1")
                optMarried.Checked = true;
            else if (dr["IsMarried"].ToString() == "0")
                optSingle.Checked = true;
            txtProvincialAddress.Text = dr["ProvincialAddress"].ToString();
            txtEmail.Text = dr["EmailAddress"].ToString();
            txtProvincialContact.Text = dr["ProvincialTelNum"].ToString();
            txtCityAddress.Text = dr["CityAddress"].ToString();
            txtCityContact.Text = dr["CityTelNum"].ToString();
            txtPreviousSchool.Text = dr["PrevSchoolAttended"].ToString();
            if (dr["PrevSchoolIsHighSchool"].ToString() == "1")
                optHighSchool.Checked = true;
            else if (dr["PrevSchoolIsHighSchool"].ToString() == "0")
                optCollege.Checked = true;
            dtpDateGraduated.Format = DateTimePickerFormat.Custom;
            dtpDateGraduated.Text = dr["DOB"].ToString();
            dtpDateGraduated.Format = DateTimePickerFormat.Long;
            txtPreviousSchoolAddress.Text = dr["PrevSchoolAddress"].ToString();
            txtVocationalSchool.Text = dr["VocSchoolAttended"].ToString();
            txtYearLevel.Text = dr["VocSchoolYearLevel"].ToString();
            txtVocationalAddress.Text = dr["VocSchoolAddress"].ToString();
            if (txtYearLevel.Text == "0") txtYearLevel.Text = "";
            if (txtVocationalAddress.Text + txtYearLevel.Text + txtVocationalSchool.Text == "")
                chkVocational.Checked = false;
            else
                chkVocational.Checked = true;
            chkF138.Checked = dr["F138"].ToString() == "1";
            chkGoodMoral.Checked = dr["GoodMoral"].ToString() == "1";
            chkNSO.Checked = dr["NSO"].ToString() == "1";
            chkTOR.Checked = dr["TOR"].ToString() == "1";
            chkHonorableDismissal.Checked = dr["HonorableDismissal"].ToString() == "1";
            chkFormalPicture.Checked = dr["FormalPicture"].ToString() == "1";
            chkMailingEnveope.Checked = dr["MailingEnvelope"].ToString() == "1";
            chkNCAE.Checked = dr["NCAE"].ToString() == "1";
            chkF137.Checked = dr["F137"].ToString() == "1";
            if (dr["IsSelfSupporting"].ToString() == "1")
                optYes.Checked = true;
            else if (dr["IsSelfSupporting"].ToString() == "0")
                optNo.Checked = true;
            txtReason.Text = dr["SelfSupportingReason"].ToString();
            txtEmployer.Text = dr["SelfSupportingEmployer"].ToString();
            txtFatherName.Text = dr["FatherName"].ToString();
            txtFatherOccupation.Text = dr["FatherOccupation"].ToString();
            txtMotherName.Text = dr["MotherName"].ToString();
            txtMotherOccupation.Text = dr["MotherOccupation"].ToString();
            txtGuardianName.Text = dr["GuardianName"].ToString();
            txtGuardianOccupation.Text = dr["GuardianOccupation"].ToString();
            cboRelation.Text = dr["RelationToGuardian"].ToString();
            txtGuardianAddress.Text = dr["GuardianAddress"].ToString();
            txtGuardianContact.Text = dr["GuardianTelNum"].ToString();
            cleared = false;
            lblSearchResult.Text = "";
        }

        private void ClearFields()
        {
            if (cleared) return;
            txtStudentSurname.Text = "";
            txtStudentFirstName.Text = "";
            txtStudentMiddleName.Text = "";
            cboCourse.Text = "";
            txtYear.Text = "";
            txtSemester.Text = "";
            txtSection.Text = "";
            optMale.Checked = false;
            optFemale.Checked = false;
            txtPOB.Text = "";
            txtNationality.Text = "";
            txtReligion.Text = "";
            optMarried.Checked = false;
            optSingle.Checked = false;
            txtProvincialAddress.Text = "";
            txtEmail.Text = "";
            txtProvincialContact.Text = "";
            txtCityAddress.Text = "";
            txtCityContact.Text = "";
            txtPreviousSchool.Text = "";
            optHighSchool.Checked = false;
            optCollege.Checked = false;
            txtPreviousSchoolAddress.Text = "";
            txtVocationalSchool.Text = "";
            txtYearLevel.Text = "";
            txtVocationalAddress.Text = "";
            chkVocational.Checked = false;
            chkF138.Checked = false;
            chkGoodMoral.Checked = false;
            chkNSO.Checked = false;
            chkTOR.Checked = false;
            chkHonorableDismissal.Checked = false;
            chkFormalPicture.Checked = false;
            chkMailingEnveope.Checked = false;
            chkNCAE.Checked = false;
            chkF137.Checked = false;
            optYes.Checked = false;
            optNo.Checked = false;
            txtReason.Text = "";
            txtEmployer.Text = "";
            txtFatherName.Text = "";
            txtFatherOccupation.Text = "";
            txtMotherName.Text = "";
            txtMotherOccupation.Text = "";
            txtGuardianName.Text = "";
            txtGuardianOccupation.Text = "";
            cboRelation.Text = "";
            txtGuardianAddress.Text = "";
            txtGuardianContact.Text = "";
            cleared = true;
        }

        private void chkVocational_CheckedChanged_1(object sender, EventArgs e)
        {
            lblVocationalAddress.Enabled = !lblVocationalAddress.Enabled;
            lblVocationalName.Enabled = !lblVocationalName.Enabled;
            lblVocationalYear.Enabled = !lblVocationalYear.Enabled;
            txtVocationalAddress.Enabled = !txtVocationalAddress.Enabled;
            txtVocationalSchool.Enabled = !txtVocationalSchool.Enabled;
            txtYearLevel.Enabled = !txtYearLevel.Enabled;
        }

        private void optNo_CheckedChanged(object sender, EventArgs e)
        {
            lblReason.Visible = false;
            lblEmployer.Visible = false;
            txtReason.Visible = false;
            txtEmployer.Visible = false;
        }

        private void optYes_CheckedChanged(object sender, EventArgs e)
        {
            lblReason.Visible = true;
            lblEmployer.Visible = true;
            txtReason.Visible = true;
            txtEmployer.Visible = true;
        }

        private void frmEditStudent_Load(object sender, EventArgs e)
        {
            DataTable dt = DB.mainDB.GetDataTable("SELECT CourseCode FROM Course_Data;");
            foreach (DataRow dr in dt.Rows)
            {
                cboCourse.Items.Add(dr["CourseCode"].ToString());
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool ValidateFields()
        {
            int j = ProgramConfig.language;
            DataTable dt = DB.mainDB.GetDataTable(string.Format("SELECT * FROM Student_Data WHERE StudentNumber = '{0}';", txtStudentNo.Text));
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(UIStrings.L.STUDENT_ALREADY_EXISTS, UIStrings.L.STUDENT_ALREADY_EXISTS_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string blanks = "";
            string required = "";
            if (txtStudentNo.Text.Trim().Length < 6)
            {
                required += (j == 1 ? "学生番号" : (j == 0 ? "Student number" : "Studanto-numero")) + "\n";
            }
            if (txtStudentSurname.Text.Trim().Length == 0)
            {
                required += (j == 1 ? "洗礼名" : (j == 0 ? "Surname" : "Familia nomo")) + "\n";
            }
            if (txtStudentFirstName.Text.Trim().Length == 0)
            {
                required += (j == 1 ? "名字" : (j == 0 ? "First name" : "Persona nomo")) + "\n";
            }
            if (txtStudentMiddleName.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "中間名" : (j == 0 ? "Middle name" : "Meza nomo")) + "\n";
            }
            if (cboCourse.Text == "" || (!cboCourse.Items.Contains(cboCourse.Text)))
            {
                required += (j == 1 ? "コース" : (j == 0 ? "Course" : "Kurso")) + "\n";
            }
            if (txtSection.Text == "")
            {
                blanks += (j == 1 ? "組" : (j == 0 ? "Section" : "Sekcio")) + "\n";
            }
            if (!(optMale.Checked || optFemale.Checked))
            {
                required += (j == 1 ? "性別" : (j == 0 ? "Sex" : "Sekso")) + "\n";
            }
            if (txtPOB.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "出生地" : (j == 0 ? "Place of birth" : "Naskiĝdomo")) + "\n";
            }
            if (txtNationality.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "国籍" : (j == 0 ? "Nationality" : "Nacieco")) + "\n";
            }
            if (txtReligion.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "宗教" : (j == 0 ? "Religion" : "Religio")) + "\n";
            }
            if (!(optMarried.Checked || optSingle.Checked))
            {
                blanks += (j == 1 ? "婚姻状態" : (j == 0 ? "Civil status" : "Civila stato")) + "\n";
            }
            if (txtProvincialAddress.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "田舎の住所" : (j == 0 ? "Provincial address" : "Provinca adreso")) + "\n";
            }
            if ((txtEmail.Text.Trim().Length == 0) || (
                txtEmail.Text.IndexOf('@') < 3)
                )
            {
                blanks += (j == 1 ? "電子メールアドレス" : (j == 0 ? "E-mail address" : "Retadreso")) + "\n";
            }
            if (txtProvincialContact.Text.Trim().Length < 11)
            {
                blanks += (j == 1 ? "田舎の連絡先" : (j == 1 ? "Provincial contact number" : "Provinca telefonnumero")) + "\n";
            }
            if (txtCityAddress.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "都市の住所" : (j == 0 ? "City address" : "Urba adreso")) + "\n";
            }
            if (txtCityContact.Text.Trim().Length < 11)
            {
                blanks += (j == 1 ? "都市の連絡先" : (j == 0 ? "City contact number" : "Urba telefonnumero")) + "\n";
            }
            if (txtPreviousSchool.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "前に通った学校" : (j == 0 ? "Previous school attended" : "Antaŭa vizitadita lernejo")) + "\n";
            }
            if (!(optHighSchool.Checked || optCollege.Checked))
            {
                blanks += (j == 1 ? "前の学校は高校か大学か" : (j == 0 ? "Type of previous school" : "Tipo de antaŭa lernejo")) + "\n";
            }
            if (txtPreviousSchoolAddress.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "前に通った学校の住所" : (j == 0 ? "Address of previous school attended" : "Adreso de antaŭa vizitadita lernejo")) + "\n";
            }
            if (chkVocational.Checked)
            {

                if (txtVocationalSchool.Text.Trim().Length == 0)
                {
                    blanks += (j == 1 ? "職業学校" : (j == 0 ? "Vocational school" : "Alvokiĝa lernejo")) + "\n";
                }
                if (txtYearLevel.Text.Trim().Length == 0)
                {
                    blanks += (j == 1 ? "職業学校の学年" : (j == 0 ? "Vocational school year level" : "Yaro je alvokiĝa lernejo")) + "\n";
                }
                if (txtVocationalAddress.Text.Trim().Length == 0)
                {
                    blanks += (j == 1 ? "職業学校の住所" : (j == 0 ? "Vocational school address" : "Adreso de alvokiĝa lernejo")) + "\n";
                }
            }
            if (!(optYes.Checked || optNo.Checked))
            {
                blanks += (j == 1 ? "一人暮らし" : (j == 0 ? "Self-supporting status" : "Vivtenulo")) + "\n";
            }
            else
            {
                if (optYes.Checked)
                {
                    if (txtReason.Text.Trim().Length == 0)
                    {
                        blanks += (j == 1 ? "一人暮らしの理由" : (j == 0 ? "Self-supporting reason" : "Kialo de vivteni")) + "\n";
                    }
                    if (txtEmployer.Text.Trim().Length == 0)
                    {
                        blanks += (j == 1 ? "雇用者・会社" : (j == 0 ? "Employer / Company" : "Labordonato / Kompanio")) + "\n";
                    }
                }
            }
            if (txtFatherName.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "父親の名前" : (j == 0 ? "Father's name" : "Nomo de patro")) + "\n";
            }
            if (txtFatherOccupation.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "父親の仕事" : (j == 0 ? "Father's occupation" : "Profesio de patro")) + "\n";
            }
            if (txtMotherName.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "母親の名前" : (j == 0 ? "Mother's name" : "Nomo de patrino")) + "\n";
            }
            if (txtMotherOccupation.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "母親の仕事" : (j == 0 ? "Mother's occupation" : "Profesio de patrino")) + "\n";
            }
            if (txtGuardianName.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "保護者の名前" : (j == 0 ? "Guardian's name" : "Nomo de gardanto")) + "\n";
            }
            if (txtGuardianOccupation.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "保護者の仕事" : (j == 0 ? "Guardian's occupation" : "Profesio de gardanto")) + "\n";
            }
            if (cboRelation.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "保護者への関係" : (j == 0 ? "Relation to guardian" : "Rilato al gardanto")) + "\n";
            }
            if (txtGuardianAddress.Text.Trim().Length == 0)
            {
                blanks += (j == 1 ? "保護者の住所" : (j == 0 ? "Guardian's address" : "Adreso de gardanto")) + "\n";
            }
            if (txtGuardianContact.Text.Trim().Length < 11)
            {
                blanks += (j == 1 ? "保護者の連絡先" : (j == 0 ? "Guardian's contact number" : "Telefonnumero de gardanto")) + "\n";
            }

            if (required.Length > 0)
            {
                MessageBox.Show(UIStrings.L.REQUIRED_FIELD + "\n\n" + required, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
                return true;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (ProgramConfig.usertype > 1)
            {
                MessageBox.Show(UIStrings.L.NO_PERMISSION, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!ValidateFields())
                return;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("StudentNumber", txtStudentNo.Text);
            data.Add("LName", txtStudentSurname.Text);
            data.Add("FName", txtStudentFirstName.Text);
            data.Add("MName", txtStudentMiddleName.Text);
            data.Add("StudentCourse", cboCourse.Text);
            if (radioButton1.Checked)
            {
                data.Add("Year", "0");
                data.Add("Semester", "0");
            }
            else if (radioButton2.Checked)
            {
                if (Convert.ToInt32(txtYear.Text) > 0)
                    data.Add("Year", txtYear.Text);
                else
                {
                    MessageBox.Show(UIStrings.L.INVALID_YEAR, UIStrings.L.INVALID_DATA, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (Convert.ToInt32(txtSemester.Text) > 0)
                    data.Add("Semester", txtSemester.Text);
                else
                {
                    MessageBox.Show(UIStrings.L.INVALID_SEMESTER, UIStrings.L.INVALID_DATA, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            else if (radioButton3.Checked)
            {
                data.Add("Year", "0");
                data.Add("Semester", "1");
            }
            else if (radioButton4.Checked)
            {
                data.Add("Year", "0");
                data.Add("Semester", "2");
            }
            else
            {
                MessageBox.Show(UIStrings.L.GENERAL_ERROR, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            data.Add("Section", txtSection.Text);
            if (optMale.Checked)
                data.Add("IsMale", "1");
            else
                data.Add("IsMale", "0");
            dtpDOB.Format = DateTimePickerFormat.Custom;
            data.Add("DOB", dtpDOB.Text);
            dtpDOB.Format = DateTimePickerFormat.Long;
            dtpEnroll.Format = DateTimePickerFormat.Custom;
            data.Add("DateEnrolled", dtpEnroll.Text);
            dtpEnroll.Format = DateTimePickerFormat.Long;
            data.Add("POB", txtPOB.Text);
            data.Add("Nationality", txtNationality.Text);
            data.Add("Religion", txtReligion.Text);
            if (optMarried.Checked)
                data.Add("IsMarried", "1");
            else
                data.Add("IsMarried", "0");
            data.Add("ProvincialAddress", txtProvincialAddress.Text);
            data.Add("EmailAddress", txtEmail.Text);
            data.Add("ProvincialTelNum", txtProvincialContact.Text);
            data.Add("CityAddress", txtCityAddress.Text);
            data.Add("CityTelNum", txtCityContact.Text);
            data.Add("PrevSchoolAttended", txtPreviousSchool.Text);
            if (optHighSchool.Checked)
                data.Add("PrevSchoolIsHighSchool", "1");
            else
                data.Add("PrevSchoolIsHighSchool", "0");
            dtpDateGraduated.Format = DateTimePickerFormat.Custom;
            data.Add("PrevSchoolGraduated", dtpDateGraduated.Text);
            dtpDateGraduated.Format = DateTimePickerFormat.Long;
            data.Add("PrevSchoolAddress", txtPreviousSchoolAddress.Text);
            data.Add("VocSchoolAttended", txtVocationalSchool.Text);
            data.Add("VocSchoolYearLevel", txtYearLevel.Text);
            data.Add("VocSchoolAddress", txtVocationalAddress.Text);
            if (chkF138.Checked)
                data.Add("F138", "1");
            else
                data.Add("F138", "0");
            if (chkGoodMoral.Checked)
                data.Add("GoodMoral", "1");
            else
                data.Add("GoodMoral", "0");
            if (chkNSO.Checked)
                data.Add("NSO", "1");
            else
                data.Add("NSO", "0");
            if (chkTOR.Checked)
                data.Add("TOR", "1");
            else
                data.Add("TOR", "0");
            if (chkHonorableDismissal.Checked)
                data.Add("HonorableDismissal", "1");
            else
                data.Add("HonorableDismissal", "0");
            if (chkFormalPicture.Checked)
                data.Add("FormalPicture", "1");
            else
                data.Add("FormalPicture", "0");
            if (chkMailingEnveope.Checked)
                data.Add("MailingEnvelope", "1");
            else
                data.Add("MailingEnvelope", "0");
            if (chkNCAE.Checked)
                data.Add("NCAE", "1");
            else
                data.Add("NCAE", "0");
            if (chkF137.Checked)
                data.Add("F137", "1");
            else
                data.Add("F137", "0");
            if (optYes.Checked)
                data.Add("IsSelfSupporting", "1");
            else
                data.Add("IsSelfSupporting", "0");
            data.Add("SelfSupportingReason", txtReason.Text);
            data.Add("SelfSupportingEmployer", txtEmployer.Text);
            data.Add("FatherName", txtFatherName.Text);
            data.Add("FatherOccupation", txtFatherOccupation.Text);
            data.Add("MotherName", txtMotherName.Text);
            data.Add("MotherOccupation", txtMotherOccupation.Text);
            data.Add("GuardianName", txtGuardianName.Text);
            data.Add("GuardianOccupation", txtGuardianOccupation.Text);
            data.Add("RelationToGuardian", cboRelation.Text);
            data.Add("GuardianAddress", txtGuardianAddress.Text);
            data.Add("GuardianTelNum", txtGuardianContact.Text);

            Dictionary<string, string> upd = new Dictionary<string, string>();
            upd["StudentCourse"] = cboCourse.Text;
            upd["StudentNumber"] = txtStudentNo.Text;

            DB.mainDB.Update("Student_Data", data, string.Format("StudentCourse = '{0}' AND StudentNumber = '{1}'", txtSearchCourse.Text, txtSearchStudentNo.Text));
            if (DB.mainDB.error)
            {
                MessageBox.Show(UIStrings.L.INVALID_INPUT, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DB.mainDB.Update("Student_EnrolledSubjects", upd, string.Format("StudentCourse = '{0}' AND StudentNumber = '{1}'", txtSearchCourse.Text, txtSearchStudentNo.Text));
            if (DB.mainDB.error)
            {
                MessageBox.Show(UIStrings.L.INVALID_INPUT, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MessageBox.Show(UIStrings.L.STUDENT_EDITED, UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtYear.Text = "";
            txtSemester.Text = "";
            txtYear.Enabled = false;
            txtSemester.Enabled = false;
            label19.Enabled = false;
            label21.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtYear.Enabled = true;
            txtSemester.Enabled = true;
            label19.Enabled = true;
            label21.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtYear.Text = "";
            txtSemester.Text = "";
            txtYear.Enabled = false;
            txtSemester.Enabled = false;
            label19.Enabled = false;
            label21.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txtYear.Text = "";
            txtSemester.Text = "";
            txtYear.Enabled = false;
            txtSemester.Enabled = false;
            label19.Enabled = false;
            label21.Enabled = false;
        }
    }
}
