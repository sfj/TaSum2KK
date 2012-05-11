using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kollegie.Web.Controls
{
    public partial class LangSelect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SelectDa(object sender, EventArgs e)
        {
            Session["lang"] = "da";
            HttpCookie langPref = Request.Cookies["Preferences"];
            langPref["lang"] = "da";
            Response.SetCookie(langPref);
            Response.Redirect(Request.RawUrl);
        }
        protected void SelectEn(object sender, EventArgs e)
        {
            Session["lang"] = "en";
            HttpCookie langPref = Request.Cookies["Preferences"];
            langPref["lang"] = "en";
            Response.SetCookie(langPref);
            Response.Redirect(Request.RawUrl);
        }
    }
}