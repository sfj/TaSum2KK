using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using System.Web.Security;
using Kollegie.Web.Controls;
using Kollegie.Web;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private Entities DB = Global.DB;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateMenu();
        LoginControl OControl = (LoginControl)LoadControl("~/Controls/LoginControl.ascx");
        Login.Controls.Add(OControl);        
    }

    /// <summary>
    /// Creates menu items and submenus from the database
    /// </summary>
    private void CreateMenu()
    {
        var punkter = from p in DB.menus where p.level == 0 select p;

        foreach(menu p in punkter) 
        {
            MenuPunktControl mpc = (MenuPunktControl)LoadControl("~/Controls/MenuPunktControl.ascx");
            mpc.punkt = p;
            Menu.Controls.Add(mpc);
        }
        LangSelect ls = (LangSelect)LoadControl("~/Controls/LangSelect.ascx");
        Menu.Controls.Add(ls);
    }
}