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

	public DataAccess(string server_mappath)
	{
        string constring, filename, file_on_server, file_on_desktop, file_path;

        filename = "_dbcon.config";

        file_on_server = server_mappath + "\\" + filename;

        file_on_desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), filename);

        file_path = File.Exists(file_on_server) ? file_on_server : file_on_desktop;
        
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