using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Net.NetworkInformation;

public static class Error
{
    public const byte OK = 0;
    public const byte ERROR = 1;
}

public static class FilePaths
{
    public const string MASTER_CONFIG = @"C:\ProgramData\StudentRecordSuite\configuration.s3db";
    public const string LICENSE =       @"C:\ProgramData\StudentRecordSuite\license.s3db";
}

public static class Tools
{
    public static void CreateDatabase(string username, string password)
    {
        SQLiteDatabase mainDB = new SQLiteDatabase(ProgramConfig.DBPath, ProgramConfig.password);
        mainDB.SetPassword(ProgramConfig.password);
        if (mainDB.DBExists())
        {
            //mainDB.CreateDB();

            // DEBUG
            mainDB.ExecuteNonQuery("CREATE TABLE Debug (A VARCHAR, B VARCHAR);");
            mainDB.ExecuteNonQuery("INSERT INTO Debug VALUES ('A', 'B');");

            // STUDENT
            mainDB.ExecuteNonQuery("CREATE TABLE Student_Data (" +
                                   "StudentCourse VARCHAR, " +
                                   "StudentNumber INT, " +
                                   "LName VARCHAR, " +
                                   "FName VARCHAR, " +
                                   "MName VARCHAR, " +
                                   "Year TINYINT, " +
                                   "DateEnrolled STRING, " +
                                   "Semester TINYINT, " +
                                   "Section VARCHAR, " +
                                   "IsMale TINYINT, " +
                                   "DOB VARCHAR, " +
                                   "POB VARCHAR, " +
                                   "Nationality VARCHAR, " +
                                   "Religion VARCHAR, " +
                                   "IsMarried SHORTINT, " +
                                   "ProvincialAddress VARCHAR, " +
                                   "EmailAddress VARCHAR, " +
                                   "ProvincialTelNum VARCHAR, " +
                                   "CityAddress VARCHAR, " +
                                   "CityTelNum VARCHAR, " +
                                   "PrevSchoolAttended VARCHAR, " +
                                   "PrevSchoolIsHighSchool TINYINT, " +
                                   "PrevSchoolGraduated VARCHAR, " +
                                   "PrevSchoolAddress VARCHAR, " +
                                   "VocSchoolAttended VARCHAR, " +
                                   "VocSchoolYearLevel TINYINT, " +
                                   "VocSchoolAddress VARCHAR, " +
                                   "F138 TINYINT, " +
                                   "GoodMoral TINYINT, " +
                                   "NSO TINYINT, " +
                                   "TOR TINYINT, " +
                                   "HonorableDismissal TINYINT, " +
                                   "FormalPicture TINYINT, " +
                                   "MailingEnvelope TINYINT, " +
                                   "NCAE TINYINT, " +
                                   "F137 TINYINT, " +
                                   "IsSelfSupporting TINYINT, " +
                                   "SelfSupportingReason VARCHAR, " +
                                   "SelfSupportingEmployer VARCHAR, " +
                                   "FatherName VARCHAR, " +
                                   "FatherOccupation VARCHAR, " +
                                   "MotherName VARCHAR, " +
                                   "MotherOccupation VARCHAR, " +
                                   "GuardianName VARCHAR, " +
                                   "GuardianOccupation VARCHAR, " +
                                   "RelationToGuardian VARCHAR, " +
                                   "GuardianAddress VARCHAR, " +
                                   "GuardianTelNum VARCHAR);");

            // STUDENT'S ENROLLED SUBJECTS
            mainDB.ExecuteNonQuery("CREATE TABLE Student_EnrolledSubjects (" +
                                   "StudentNumber INT, " +
                                   "StudentCourse VARCHAR, " +
                                   "SubjectCode VARCHAR, " +
                                   "ProfessorCode VARCHAR, " +
                                   "Date VARCHAR, " +
                                   "FinalGrade VARCHAR, " +
                                   "ReExamGrade VARCHAR);");

            // SUBJECT
            mainDB.ExecuteNonQuery("CREATE TABLE Subject_Data (" +
                                   "SubjectCode VARCHAR, " +
                                   "SubjectName VARCHAR, " +
                                   "LectureUnits INT, " +
                                   "LaboratoryUnits INT, " +
                                   "IsAcademic TINYINT);");


            // SUBJECT PREREQUISITES
            mainDB.ExecuteNonQuery("CREATE TABLE Subject_Prerequisites (" +
                                   "SubjectCode VARCHAR, " +
                                   "PrerequisiteCode VARCHAR);");

            // SUBJECT COREQUISITES
            mainDB.ExecuteNonQuery("CREATE TABLE Subject_Corequisites (" +
                                   "SubjectCode VARCHAR, " +
                                   "CorequisiteCode VARCHAR);");


            // COURSE
            mainDB.ExecuteNonQuery("CREATE TABLE Course_Data (" +
                                   "CourseName VARCHAR, " +
                                   "CourseCode VARCHAR);");

            // COURSE SUBJECTS
            mainDB.ExecuteNonQuery("CREATE TABLE Course_Subjects (" +
                                   "CourseCode VARCHAR, " +
                                   "YearName INT, " +
                                   "SemesterName INT, " +
                                   "SubjectCode VARCHAR);");

            // PROFESSOR
            mainDB.ExecuteNonQuery("CREATE TABLE Professor_Data (" +
                                   "ProfessorCode VARCHAR, " +
                                   "FName VARCHAR, " +
                                   "LName VARCHAR);");

            // users
            mainDB.ExecuteNonQuery("CREATE TABLE Users (" +
                                   "Username VARCHAR, " +
                                   "Password, " +
                                   "Type INT);");
            Dictionary<string, string> admin = new Dictionary<string, string>()
            {
                {"Username", username },
                {"Password", password },
                {"Type", "0" }
            };
            mainDB.Insert("Users", admin);
        }
    }

}

public static class DB
{
    public static SQLiteDatabase mainDB;
    public static SQLiteDatabase configDB;
}

public static class UIStrings
{
    public static LangString L;
}

public class Semester
{
    public string name;
    public List<string> subjects;

    public Semester(string n)
    {
        name = n;
        subjects = new List<string>();
    }
}

public class Year
{
    public string name;
    public List<Semester> semesters;

    public Year(string n)
    {
        name = n;
        semesters = new List<Semester>();
    }
}

public static class DT2HTML
{
    public static void Export(string name, string course, string year, string section, DataTable dt, string path)
    {
        DateTime now = DateTime.Now;
        IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
        string localhost = computerProperties.HostName;

        using (StreamWriter html = new StreamWriter(path))
        {
            html.Write("<!doctype html><html><head><meta charset=\"utf-8\"><title>");
            html.Write(name);
            html.Write(" - GradeReport</title></head><body><h1>StudentRecordSuite Grade Report</h1><p>Report generated on ");
            html.Write(now.ToLongDateString() + ", " + now.ToLongTimeString());
            html.Write(" by " + localhost);
            html.Write("</p><table width=\"100%\" border=\"0\"><tbody><tr><th width=\"11%\" style=\"text-align: left\" scope=\"row\">Name:</th><td width=\"89%\" style=\"text-align: left\">");
            html.Write(name);
            html.Write("</td></tr><tr><th style=\"text-align: left\" scope=\"row\">Course:</th><td style=\"text-align: left\">");
            html.Write(course);
            html.Write("</td></tr><tr><th style=\"text-align: left\" scope=\"row\">Year:</th><td style=\"text-align: left\">");
            html.Write(year);
            html.Write("</td></tr>");
            if (section.Trim().Length > 0)
            {
                html.Write("<tr><th style=\"text-align: left\" scope=\"row\">Section:</th><td style=\"text-align: left\">");
                html.Write(section);
                html.Write("</td></tr>");
            }
            html.Write("</tbody></table><p>&nbsp;</p><table width=\"100%\" border=\"0\"><tbody><tr><th width=\"26%\" scope=\"col\">Date enrolled</th><th width=\"56%\" scope=\"col\">Subject</th><th width=\"18%\" scope=\"col\">Grade</th></tr>");
            foreach (DataRow dr in dt.Rows)
            {
                html.Write("<tr><td>");
                html.Write(dr["Date Enrolled"].ToString());
                html.Write("</td><td>");
                html.Write(dr["Subject Code"].ToString());
                html.Write("</td><td>");
                html.Write(dr["Final Grade"].ToString());
                html.Write("</td></tr>");
            }
            html.Write("</tbody></table></body></html>");

            SQLiteDatabase license = new SQLiteDatabase(FilePaths.LICENSE);
            if (!license.DBExists())
            {
                license.CreateDB();
                license.ExecuteNonQuery("CREATE TABLE License (Key VARCHAR);");
            }
            DataTable dt3 = license.GetDataTable("SELECT Key FROM License;");
            string s = dt3.Rows[0]["Key"].ToString();

            html.Write("<p style=\"color: #FFFFFF\">Program serial key: " + s + "</p>");
            html.Close();
        }

    }
} 