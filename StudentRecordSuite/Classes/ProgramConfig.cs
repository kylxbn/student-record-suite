using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

static class ProgramConfig

{
    public static string DBPath = @"C:\ProgramData\StudentRecordSuite\mainDB.s3db";
    public static int language = 0;
    public static int windowWidth = 597;
    public static int windowHeight = 509;
    public static int windowX = 20;
    public static int windowY = 10;
    public const string password = "zPfw96C20pdduFa0H";
    public static int gradUnits = 20;
    public static int nongradUnits = 18;
    public static int usertype = 2;
    public static string username = "";

    public static void WriteConfig(bool quiet = true)
    {
        SQLiteDatabase settings = new SQLiteDatabase(FilePaths.MASTER_CONFIG);
        if (!settings.DBExists()) settings.CreateDB();
        settings.ExecuteNonQuery("DROP TABLE IF EXISTS ProgramConfig;");
        settings.ExecuteNonQuery("CREATE TABLE ProgramConfig (Language INT, ConfigPath VARCHAR, WindowWidth INT, WindowHeight INT, WindowX INT, WindowY INT, GradUnits INT, NongradUnits INT, LastUpdate INT, RemindUpdate INT);");
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["Language"] = language.ToString();
        data["ConfigPath"] = DBPath;
        data["WindowWidth"] = windowHeight.ToString();
        data["WindowHeight"] = windowWidth.ToString();
        data["WindowX"] = windowX.ToString();
        data["WindowY"] = windowY.ToString();
        data["GradUnits"] = gradUnits.ToString();
        data["NongradUnits"] = nongradUnits.ToString();
        settings.Insert("ProgramConfig", data);
        if (!quiet) 
            MessageBox.Show(UIStrings.L.SETTINGS_UPDATED, UIStrings.L.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void LoadConfig()
    {
        DataTable dt = DB.configDB.GetDataTable("SELECT * FROM ProgramConfig;");
        foreach (DataRow dr in dt.Rows)
        {
            language = Convert.ToInt32(dr["Language"].ToString());
            DBPath = dr["ConfigPath"].ToString();
            windowWidth = Convert.ToInt32(dr["WindowWidth"].ToString());
            windowHeight = Convert.ToInt32(dr["WindowHeight"].ToString());
            windowX = Convert.ToInt32(dr["WindowX"].ToString());
            windowY = Convert.ToInt32(dr["WindowY"].ToString());
            gradUnits = Convert.ToInt32(dr["GradUnits"].ToString());
            nongradUnits = Convert.ToInt32(dr["NongradUnits"].ToString());
        }

        if (language == 0)
        {
            UIStrings.L = new English();
        }
        else if (language == 1)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja");
            UIStrings.L = new Japanese();
        }
        else if (language == 2)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("eo");
            UIStrings.L = new Esperanto();
        }
        else
        {
            UIStrings.L = new English();
        }
    }
}
