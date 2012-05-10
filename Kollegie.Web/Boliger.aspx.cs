using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using Kollegie.Web.Controls;
using Kollegie.Web;


public partial class Boliger : System.Web.UI.Page
{
    private Entities DB = Global.DB;

    protected void Page_Load(object sender, EventArgs e)
    {
        var temp = from t in DB.boligs select t;

        foreach (var t in temp)
        {
            BoligContent.Controls.Add(new Literal()
            {
                Text = string.Format("<tr><td valign=\"top\" class=\"housephoto\"><img src=\"http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement\" height=\"180\" width=\"220\" /></td>" +
                    "<td valign=\"top\" width=\"125\"><span class=\"bold\">Pris pr. måned:</span><br />{1} kr<br /><br /><span class=\"bold\">A/C udgifter:</span><br />{8} kr<br /><br /><span class=\"bold\">Samlet:</span><br />{9} kr<br /><br /><span class=\"bold\">Depositum:</span><br/>{2} kr<br/><br/><span class=\"bold\">Ventetid:</span><br/>{3}<br/><br/></td>" +
                    "<td valign=\"top\"><a href=\"rosbolig.aspx?rediger={7}\">Rediger</a> &nbsp;<a href=\"rosbolig.aspx?slet={7}\">Slet</a><br /><br />{4}<br /><br /><span class=\"bold\">Afdeling:</span><br />{6}</td><td valign=\"top\">Område:<br/>{5}</td></tr>", t.department1.description_dk, t.monthly_price, t.deposit, 300, t.description_dk, t.area, t.department1.name, t.id, t.ac_expenses, t.ac_expenses + t.monthly_price)
            });
        }
    }
}
