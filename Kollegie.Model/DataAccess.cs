using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Kollegie.Model;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{

    private static DataAccess uniqueInstance;
    private static Object lockObj = new Object();

    private Entities db;

    public Entities DB
    {
        get { return db; }
    }

	public DataAccess(string mappath)
	{
        string constring;

        string filename = "_dbcon.config";


        string file_path = File.Exists(mappath + "\\" + filename) ? mappath + "\\" + filename : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), filename);
        
        TextReader tr = new StreamReader(file_path);

        constring = tr.ReadLine();

        tr.Close();

        System.Diagnostics.Debug.WriteLine("Loaded: " + constring + ", From: " + file_path);

        db = new Entities(constring);
	}

    public static DataAccess getDataAccess(string mappath)
    {
        if (uniqueInstance == null)
        {
            lock(lockObj) 
            {
                uniqueInstance = uniqueInstance == null ? new DataAccess(mappath) : uniqueInstance;
            }
            
        }
        return uniqueInstance;
    }
}