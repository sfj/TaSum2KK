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
        //where
        //pris < ?
        //kat >= ?, kat = 0
        //hund >= ? hund = 0
        //andre dyr >= ? andre dyr = 0
        //børn 0 || 1
        //eget bad 0 || 1
        //eget køkken 0 || 1
        //antal vær >= ?
        //fritekst LIKE %?%
        OpretTableRow.Controls.Add(new Literal()
                                       {
                                           Text = "<tr>\n" +
                                            "<td colspan=\"4\" align=\"right\"><a href=\"rosbolig.aspx?opret=make\">Opret bolig</a></td>" +
                                            "</tr>"
                                       });
        user u = ((user)Session["user"]);
        bool ros_visible;
        if (u != null && u.userlevel <= 2)
        {
            ros_visible = true;
        }
        else
        {
            ros_visible = false;
        }

        OpretTableRow.Visible = ros_visible;

        if (((string)Session["lang"]) == "da")
        {
            sortby.Text = "Sorter efter:";
            price.Text = "Pris";
            waittime.Text = "Ventetid";
            department.Text = "Afdeling";
        }
        else
        {
            sortby.Text = "Sort by:";
            price.Text = "Price";
            waittime.Text = "Wait time";
            department.Text = "Department";
        }

        foreach (var t in temp)
        {
            if(((string)Session["lang"]) == "da")
            {
                string links =
                    (ros_visible) ? string.Format("<a href=\"rosbolig.aspx?rediger={0}\">Rediger</a> &nbsp;<a href=\"rosbolig.aspx?slet={0}\">Slet</a><br /><br />", t.id) : "";
                BoligContent.Controls.Add(new Literal() {
                Text = string.Format("<tr><td valign=\"top\" class=\"housephoto\"><img src=\"http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement\" height=\"180\" width=\"220\" /></td>" +
                    "<td valign=\"top\" width=\"125\"><span class=\"bold\">Pris pr. måned:</span><br />{1} kr<br /><br /><span class=\"bold\">A/C udgifter:</span><br />{8} kr<br /><br /><span class=\"bold\">Samlet:</span><br />{9} kr<br /><br /><span class=\"bold\">Depositum:</span><br/>{2} kr<br/><br/><span class=\"bold\">Ventetid:</span><br/>{3}<br/><br/></td>" +
                    "<td valign=\"top\">{7}{4}<br /><br /><span class=\"bold\">Afdeling:</span><br />{6}</td><td valign=\"top\">Område:<br/>{5}</td></tr>", t.department1.description_dk, t.monthly_price, t.deposit, 300, t.description_dk, t.area, t.department1.name, links, t.ac_expenses, t.ac_expenses + t.monthly_price)
                });
            }
            else 
            {
                BoligContent.Controls.Add(new Literal() {
                Text = string.Format("<tr><td valign=\"top\" class=\"housephoto\"><img src=\"http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement\" height=\"180\" width=\"220\" /></td>" +
                    "<td valign=\"top\" width=\"125\"><span class=\"bold\">Price pr. month:</span><br />{1} dkr<br /><br /><span class=\"bold\">A/C expenses:</span><br />{8} dkr<br /><br /><span class=\"bold\">Total:</span><br />{9} dkr<br /><br /><span class=\"bold\">Deposit:</span><br/>{2} dkr<br/><br/><span class=\"bold\">Wait time:</span><br/>{3}<br/><br/></td>" +
                    "<td valign=\"top\"><a href=\"rosbolig.aspx?rediger={7}\">Rediger</a> &nbsp;<a href=\"rosbolig.aspx?slet={7}\">Slet</a><br /><br />{4}<br /><br /><span class=\"bold\">Department:</span><br />{6}</td><td valign=\"top\">Area:<br/>{5}</td></tr>", t.department1.description_en, t.monthly_price, t.deposit, 300, t.description_en, t.area, t.department1.name, t.id, t.ac_expenses, t.ac_expenses + t.monthly_price)
                });
            }           
        }
    }
}
