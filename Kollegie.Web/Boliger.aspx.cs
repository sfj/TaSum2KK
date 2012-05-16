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

        // building query with method syntax:
        IQueryable<bolig> query = DB.boligs; // initialise query
        bolig bolig_result = (bolig)Session["search_result"];
        if(bolig_result != null){

            if (bolig_result.monthly_price != -1) // add filters with filter methods
            {
                query = query.Where<bolig>(b => b.monthly_price < bolig_result.monthly_price);
            }
            if (bolig_result.cat_amount != -1)
            {
                query = query.Where<bolig>(b => b.cat_amount >= bolig_result.cat_amount);
            }
            if (bolig_result.dog_amount != -1)
            {
                query = query.Where<bolig>(b => b.dog_amount >= bolig_result.dog_amount);
            }
            if (bolig_result.small_pets_amount != -1) {
                query = query.Where<bolig>(b => b.small_pets_amount >= bolig_result.small_pets_amount);
            }
            if (bolig_result.department != -1) {
                query = query.Where<bolig>(b => b.department == bolig_result.department);
            }
            if (bolig_result.persons != -1) {
                query = query.Where<bolig>(b => b.persons >= bolig_result.persons);
            }
            if (bolig_result.children == 1) {
                query = query.Where<bolig>(b => b.children == bolig_result.children);
            }
            if (bolig_result.kitchen == 1) {
                query = query.Where<bolig>(b => b.kitchen == bolig_result.kitchen);
            }
            if (bolig_result.bath == 1) {
                query = query.Where<bolig>(b => b.bath == bolig_result.bath);
            }
            if (bolig_result.rooms != -1) {
                query = query.Where<bolig>(b => b.rooms >= bolig_result.rooms);
            }
            if (bolig_result.surfacearea != -1) {
                query = query.Where<bolig>(b => b.surfacearea >= bolig_result.surfacearea);
            }
            if (bolig_result.description_dk != null) {
                if (Session["lang"] == "da") {
                    query = query.Where<bolig>(b => b.description_dk.Contains(bolig_result.description_dk));
                }
                else if(Session["lang"] == "en") {
                    query = query.Where<bolig>(b => b.description_en.Contains(bolig_result.description_en));
                }
            }
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

        foreach (var t in query)
        {
            string links =
                       (ros_visible) ? string.Format("<a href=\"rosbolig.aspx?rediger={0}\">Rediger</a> &nbsp;<a href=\"rosbolig.aspx?slet={0}\">Slet</a><br /><br />", t.id) : "";
                
            if(((string)Session["lang"]) == "da")
            {
                BoligContent.Controls.Add(new Literal() {
                Text = string.Format("<tr><td valign=\"top\" class=\"housephoto\"><img src=\"http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement\" height=\"180\" width=\"220\" /></td>" +
                    "<td valign=\"top\" width=\"125\"><span class=\"bold\">Pris pr. måned:</span><br />{1} kr<br /><br /><span class=\"bold\">A/C udgifter:</span><br />{8} kr<br /><br /><span class=\"bold\">Samlet:</span><br />{9} kr<br /><br /><span class=\"bold\">Depositum:</span><br/>{2} kr<br/><br/><span class=\"bold\">Ventetid:</span><br/>{3}<br/><br/></td>" +
                    "<td valign=\"top\">{7}{4}<br /><br /><span class=\"bold\">Afdeling:</span><br />{6} {0}<br /><br /><span class=\"bold\">Værelser:</span> {10} <span class=\"bold\">Personer:</span> {11} <span class=\"bold\">Børn:</span> {12}<br /><br /><span class=\"bold\">Kat tilladt:</span> {13} <span class=\"bold\">Hund tilladt:</span> {14} <span class=\"bold\">Små kæledyr tilladt:</span> {15}<br /><br /><span class=\"bold\">Eget bad:</span> {16} <span class=\"bold\">Eget Køkken:</span> {17}</td><td valign=\"top\">Område:<br/>{5}</td></tr>", t.department1.description_dk, t.monthly_price, t.deposit, 300, t.description_dk, t.area, t.department1.name, links, t.ac_expenses, t.ac_expenses + t.monthly_price, t.rooms, t.persons, t.children, t.cat_amount, t.dog_amount, t.small_pets_amount, t.bath, t.kitchen)
                });
            }
            else 
            {
                BoligContent.Controls.Add(new Literal()
                {
                    Text = string.Format("<tr><td valign=\"top\" class=\"housephoto\"><img src=\"http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement\" height=\"180\" width=\"220\" /></td>" +
                    "<td valign=\"top\" width=\"125\"><span class=\"bold\">Monthly rent:</span><br />{1} kr<br /><br /><span class=\"bold\">A/C expenses:</span><br />{8} kr<br /><br /><span class=\"bold\">Total:</span><br />{9} kr<br /><br /><span class=\"bold\">Deposit:</span><br/>{2} kr<br/><br/><span class=\"bold\">Wait time:</span><br/>{3}<br/><br/></td>" +
                    "<td valign=\"top\">{7}{4}<br /><br /><span class=\"bold\">Department:</span><br />{6} {0}<br /><br /><span class=\"bold\">Rooms:</span> {10} <span class=\"bold\">Persons:</span> {11} <span class=\"bold\">Children:</span> {12}<br /><br /><span class=\"bold\">Cats allowed:</span> {13} <span class=\"bold\">Dogs allowed:</span> {14} <span class=\"bold\">Small pets allowed:</span> {15}<br /><br /><span class=\"bold\">Own bath:</span> {16} <span class=\"bold\">Own kitchen:</span> {17}</td><td valign=\"top\">Area:<br/>{5}</td></tr>", t.department1.description_en, t.monthly_price, t.deposit, 300, t.description_en, t.area, t.department1.name, links, t.ac_expenses, t.ac_expenses + t.monthly_price, t.rooms, t.persons, t.children, t.cat_amount, t.dog_amount, t.small_pets_amount, t.bath, t.kitchen)
                });
            }           
        }
    }
}
