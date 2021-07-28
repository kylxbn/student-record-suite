using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

public class SQLiteDatabase
{
    string dbConnection;
    string dbFileName;

    const bool debug = false;
    public bool error = false;
    public string errormsg = "";

    /// <summary>
    ///     Single Param Constructor for specifying the DB file.
    /// </summary>
    /// <param name="inputFile">The File containing the DB</param>
    public SQLiteDatabase(string inputFile)
    {
        dbFileName = inputFile;
        try
        {
            dbConnection = string.Format("Data Source={0}; Version=3;", inputFile);
            error = false;
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
        }
    }

    /// <summary>
    ///     Double Param Constructor for specifying the DB file with Password.
    /// </summary>
    /// <param name="inputFile">The File containing the DB</param>
    public SQLiteDatabase(string inputFile, string password)
    {
        dbFileName = inputFile;
        try
        {
            dbConnection = string.Format("Data Source={0}; Version=3; Password={1};", inputFile, password);
            error = false;
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
        }
    }

    /// <summary>
    ///     Check if a database exists.
    /// </summary>
    /// <returns>True if the file exists else false.</returns>
    public bool DBExists()
    {
        try
        {
            if (File.Exists(dbFileName))
            {
                error = false;
                return true;
            }
            else
            {
                error = false;
                return false;
            }
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
            return false;
        }
    }

    /// <summary>
    ///     Create a database.
    /// </summary>
    /// <returns>True if the file exists else false.</returns>
    public void CreateDB()
    {
        try
        {
            bool exists = System.IO.Directory.Exists(Path.GetDirectoryName(dbFileName));
            if (!exists)
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(dbFileName));
            SQLiteConnection.CreateFile(dbFileName);
            error = false;
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
        }
    }

    /// <summary>
    ///     Set password.
    /// </summary>
    /// <param name="pw">the password</param>
    public void SetPassword(string pw)
    {
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.SetPassword(pw);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = "CREATE TABLE Debug (A VARCHAR, B VARCHAR); INSERT INTO Debug VALUES ('A', 'B');";
            mycommand.ExecuteNonQuery();
            cnn.Close();
            error = false;
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
        }
    }

    public void ChangePassword(string pw)
    {
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.ChangePassword(pw);
            error = false;
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
        }
    }



    /// <summary>
    ///     Allows the programmer to run a query against the Database.
    /// </summary>
    /// <param name="sql">The SQL to run</param>
    /// <returns>A DataTable containing the result set.</returns>
    public DataTable GetDataTable(string sql)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            SQLiteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
            error = false;
        }
        catch (Exception e)
        {
            if (debug)
            {
                MessageBox.Show(UIStrings.L.DATABASE_READ_ERROR, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(e.Message);
                MessageBox.Show(sql);
                Application.Exit();
            }
            else
            {
                error = true;
                errormsg = e.Message;
            }
        }
        return dt;
    }

    /// <summary>
    ///     Allows the programmer to interact with the database for purposes other than a query.
    /// </summary>
    /// <param name="sql">The SQL to be run.</param>
    /// <returns>An Integer containing the number of rows updated.</returns>
    public int ExecuteNonQuery(string sql)
    {
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            error = false;
            return rowsUpdated;
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
            return 0;
        }
    }

    /// <summary>
    ///     Allows the programmer to retrieve single items from the DB.
    /// </summary>
    /// <param name="sql">The query to run.</param>
    /// <returns>A string.</returns>
    public string ExecuteScalar(string sql)
    {
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                error = false;
                return value.ToString();
            }
        }
        catch (Exception e)
        {
            error = true;
            errormsg = e.Message;
        }

        return "";
    }

    /// <summary>
    ///     Allows the programmer to easily update rows in the DB.
    /// </summary>
    /// <param name="tableName">The table to update.</param>
    /// <param name="data">A dictionary containing Column names and their new values.</param>
    /// <param name="where">The where clause for the update statement.</param>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool Update(string tableName, Dictionary<string, string> data, string where)
    {
        string vals = "";
        Boolean returnCode = true;
        if (data.Count >= 1)
        {
            foreach (KeyValuePair<string, string> val in data)
            {
                vals += string.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
            }
            vals = vals.Substring(0, vals.Length - 1);
        }
        try
        {
            this.ExecuteNonQuery(string.Format("update {0} set {1} where {2};", tableName, vals, where));
            error = false;
        }
        catch (Exception fail)
        {
            if (debug)
            {
                returnCode = false;
                MessageBox.Show(UIStrings.L.DATABASE_WRITE_ERROR, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(fail.Message);
                Application.Exit();
            }
            else
            {
                error = true;
                errormsg = fail.Message;
            }
        }
        return returnCode;
    }

    /// <summary>
    ///     Allows the programmer to easily delete rows from the DB.
    /// </summary>
    /// <param name="tableName">The table from which to delete.</param>
    /// <param name="where">The where clause for the delete.</param>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool Delete(string tableName, string where)
    {
        bool returnCode = true;
        try
        {
            this.ExecuteNonQuery(string.Format("delete from {0} where {1};", tableName, where));
            error = false;
        }
        catch (Exception fail)
        {
            if (debug)
            {
                MessageBox.Show(UIStrings.L.DATABASE_DELETE_ERROR, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(fail.Message);
                Application.Exit();
            }
            else
            {
                error = true;
                errormsg = fail.Message;
            }
        }
        return returnCode;
    }

    /// <summary>
    ///     Allows the programmer to easily insert into the DB
    /// </summary>
    /// <param name="tableName">The table into which we insert the data.</param>
    /// <param name="data">A dictionary containing the column names and data for the insert.</param>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool Insert(string tableName, Dictionary<string, string> data)
    {
        string columns = "";
        string values = "";
        Boolean returnCode = true;
        foreach (KeyValuePair<string, string> val in data)
        {
            columns += string.Format(" {0},", val.Key.ToString());
            values += string.Format(" '{0}',", val.Value);
        }
        columns = columns.Substring(0, columns.Length - 1);
        values = values.Substring(0, values.Length - 1);
        try
        {
            this.ExecuteNonQuery(string.Format("insert into {0}({1}) values({2});", tableName, columns, values));
            error = false;
        }
        catch (Exception fail)
        {
            if (debug)
            {
                MessageBox.Show(UIStrings.L.DATABASE_INSERT_ERROR, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(fail.Message);
                Application.Exit();
            }
            else
            {
                error = true;
                errormsg = fail.Message;
            }
        }
        return returnCode;
    }

    /// <summary>
    ///     Allows the programmer to easily delete all data from the DB.
    /// </summary>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool ClearDB()
    {
        DataTable tables;
        try
        {
            tables = this.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by ;");
            foreach (DataRow table in tables.Rows)
            {
                this.ClearTable(table["NAME"].ToString());
                error = false;
            }
            return true;
        }
        catch (Exception fail)
        {
            if (debug)
            {
                MessageBox.Show(UIStrings.L.DATABASE_DELETE_ERROR, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(fail.Message);
                Application.Exit();
            }
            else
            {
                error = true;
                errormsg = fail.Message;
            }
            return false;
        }
    }

    /// <summary>
    ///     Allows the user to easily clear all data from a specific table.
    /// </summary>
    /// <param name="table">The name of the table to clear.</param>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool ClearTable(string table)
    {
        try
        {
            this.ExecuteNonQuery(string.Format("delete from {0};", table));
            error = false;
            return true;
        }
        catch (Exception fail)
        {
            if (debug)
            {
                MessageBox.Show(UIStrings.L.DATABASE_DELETE_ERROR, UIStrings.L.GENERAL_ERROR_L, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(fail.Message);
                Application.Exit();
            }
            else
            {
                error = true;
                errormsg = fail.Message;
            }
            return false;
        }
    }
}