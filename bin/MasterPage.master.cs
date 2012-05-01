using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tempdbModel;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateMenu();

        if (IsPostBack)
        {
            if (loginform.Visible == true)
            {
                ValidateLogin();
            }
        }
        if (Session["user"] != null)
        {
            loginform.Visible = false;
            LoggedIn.Controls.Add(new Literal() { Text = "Velkommen " + ((user)Session["user"]).username });
        }
        else
        {
            loginform.Visible = true;
        }
    }

    private void ValidateLogin()
    {
        tempdbEntities DB = new tempdbEntities();

        string name = userlogin.Text;
        string pass = userpass.Text;

        tempdbModel.user user = (from u in DB.users where u.username == name && u.password == pass select u).SingleOrDefault();

        if (user != null)
        {
            user.password = "";
            Session["user"] = user;
        }
        else
        {
            Response.Redirect("LoginError.aspx");
        }
    }

    /// <summary>
    /// Creates menu items and submenus from the database
    /// </summary>
    private void CreateMenu()
    {
        tempdbEntities DB = new tempdbEntities();

        var punkter = from p in DB.menus where p.level == 0 select p;

        foreach(menu p in punkter) {
            Literal tag = new Literal() 
            { 
                Text = "<td class=\"menupunkt\" onMouseOver=\"justshow('dd" + p.id + "');\" onMouseOut=\"justhide('dd" + p.id + "');\">"
            };
            Menu.Controls.Add(tag);

            HyperLink link = new HyperLink()
            {
                CssClass = "menu_link",
                Text = p.text_dk,
                NavigateUrl = p.skabelon.filename + "?id=" + p.id
            };            
            Menu.Controls.Add(link);

            tag = new Literal() 
            { 
                Text = "<div class=\"dd_div\" id=\"dd" + p.id + "\">" 
            };
            Menu.Controls.Add(tag);

            Table sub = new Table() 
            { 
                CssClass = "dropdown",
                CellPadding = 0,
                CellSpacing = 0
            };            

            var subpunkter = from s in DB.menus where s.level == 1 && s.parent == p.id select s;

            foreach (menu s in subpunkter)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell()
                {
                    CssClass = "dd_menupunkt"
                };

                HyperLink sublink = new HyperLink() 
                {
                    CssClass = "dd_menulink",
                    Text = s.text_dk,
                    NavigateUrl = s.skabelon.filename + "?id=" + s.id
                };                

                cell.Controls.Add(sublink);
                row.Cells.Add(cell);
                sub.Rows.Add(row);
            }
            Menu.Controls.Add(sub);

            tag = new Literal() 
            {
                Text = "</div></td>"
            };
            
            Menu.Controls.Add(tag);
        }
    }
}