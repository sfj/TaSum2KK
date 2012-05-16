using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using System.Web.Security;

namespace Kollegie.Web.Controls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        private Entities DB = Global.DB;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (IsPostBack)
            {
                if (LoginTable.Visible && (Session["user"] == null))
                {
                    ValidateLogin();
                }
            }
            if (Session["user"] != null)
            {
                LoginTable.Visible = false;
                LoginText.InnerText = (((string)Session["lang"]) == "da" ? "Velkommen " : "Welcome ") + ((user) Session["user"]).username;
                LogoutTable.Visible = true;
            }
            else
            {
                LoginTable.Visible = true;
                LogoutTable.Visible = false;
            }
        }

        protected void LogoutButtonClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            FormsAuthentication.SignOut();
            Response.Redirect(Request.RawUrl);
        }

        private void ValidateLogin()
        {
            string name = userlogin.Text;
            string pass = userpass.Text;
            user user = (from u in DB.users where u.username == name && u.password == pass select u).SingleOrDefault();

            if (user != null)
            {
                user.password = "";
                Session["user"] = user;
                FormsAuthentication.SetAuthCookie(user.username, true);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Redirect("LoginError.aspx");
            }
            
        }
    }
}