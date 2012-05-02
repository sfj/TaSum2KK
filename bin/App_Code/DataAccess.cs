using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{

    private static DataAccess uniqueInstance;
    private static Object lockObj = new Object();

    private tempdbModel.Entities db;

    public tempdbModel.Entities DB
    {
        get { return db; }
    }

	public DataAccess()
	{
        string constring;

        string file_path = File.Exists("_dbcon.txt") ? "_dbcon.txt" : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "_dbcon.txt");

        TextReader tr = new StreamReader(file_path);

        constring = tr.ReadLine();

        tr.Close();

        System.Diagnostics.Debug.WriteLine("Loaded: " + constring + ", From: " + file_path);

        db = new tempdbModel.Entities(constring);
	}

    public static DataAccess getDataAccess()
    {
        if (uniqueInstance == null)
        {
            lock(lockObj) 
            {
                uniqueInstance = uniqueInstance == null ? new DataAccess() : uniqueInstance;
            }
            
        }
        return uniqueInstance;
    }
}