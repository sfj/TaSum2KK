using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((string)Session["lang"]) == "da")
        {
            errortekst.Text = "Brugernavn og/eller password var ikke korrekt. <br /> <br /> Prøv igen.";
        }
        else
        {
            errortekst.Text = "Username and/or password wasn't correct. <br /> <br /> Try again.";
        }
        if (Session["user"] != null)
        {
            Response.Redirect("Forside.aspx");
        }
    }
}