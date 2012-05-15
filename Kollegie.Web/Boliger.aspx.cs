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

        // building query with method syntax:
        IQueryable<bolig> query = DB.boligs; // initialise query
        int pris = 3000; // get variables
        int cats = 2;
        int dogs = 1;
        if (pris > 0) // add filters with filter methods
        {
            query = query.Where<bolig>(b => b.monthly_price < pris);
        }
        if (cats > 0)
        {
            query = query.Where<bolig>(b => b.cat_amount >= cats);
        }
        else
        {
            query = query.Where<bolig>(b => b.cat_amount == 0);
        }
        if (dogs > 0)
        {
            query = query.Where<bolig>(b => b.dog_amount >= dogs);
        }
        else
        {
            query = query.Where<bolig>(b => b.dog_amount == 0);
        }

        query = query.Select(b => b); // finally select boliger, optionally order etc.

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
            string links =
                       (ros_visible) ? string.Format("<a href=\"rosbolig.aspx?rediger={0}\">Rediger</a> &nbsp;<a href=\"rosbolig.aspx?slet={0}\">Slet</a><br /><br />", t.id) : "";
                
            if(((string)Session["lang"]) == "da")
            {
                BoligContent.Controls.Add(new Literal() {
                Text = string.Format("<tr><td valign=\"top\" class=\"housephoto\"><img src=\"http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement\" height=\"180\" width=\"220\" /></td>" +
                    "<td valign=\"top\" width=\"125\"><span class=\"bold\">Pris pr. måned:</span><br />{1} kr<br /><br /><span class=\"bold\">A/C udgifter:</span><br />{8} kr<br /><br /><span class=\"bold\">Samlet:</span><br />{9} kr<br /><br /><span class=\"bold\">Depositum:</span><br/>{2} kr<br/><br/><span class=\"bold\">Ventetid:</span><br/>{3}<br/><br/></td>" +
                    "<td valign=\"top\">{7}{4}<br /><br /><span class=\"bold\">Afdeling:</span><br />{6}. {0}</td><td valign=\"top\">Område:<br/>{5}</td></tr>", t.department1.description_dk, t.monthly_price, t.deposit, 300, t.description_dk, t.area, t.department1.name, links, t.ac_expenses, t.ac_expenses + t.monthly_price)
                });
            }
            else 
            {
                BoligContent.Controls.Add(new Literal()
                {
                    Text = string.Format("<tr><td valign=\"top\" class=\"housephoto\"><img src=\"http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement\" height=\"180\" width=\"220\" /></td>" +
                        "<td valign=\"top\" width=\"125\"><span class=\"bold\">Pris pr. måned:</span><br />{1} kr<br /><br /><span class=\"bold\">A/C udgifter:</span><br />{8} kr<br /><br /><span class=\"bold\">Samlet:</span><br />{9} kr<br /><br /><span class=\"bold\">Depositum:</span><br/>{2} kr<br/><br/><span class=\"bold\">Ventetid:</span><br/>{3}<br/><br/></td>" +
                        "<td valign=\"top\">{7}{4}<br /><br /><span class=\"bold\">Afdeling:</span><br />{6}</td><td valign=\"top\">Område:<br/>{5}</td></tr>", t.department1.description_dk, t.monthly_price, t.deposit, 300, t.description_en, t.area, t.department1.name, links, t.ac_expenses, t.ac_expenses + t.monthly_price)

                });
            }           
        }
    }
}
