using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;

public partial class rosbolig : System.Web.UI.Page
{
    private Entities DB = DataAccess.getDataAccess().DB;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["opret"] != null && Request.QueryString["opret"].Equals("make"))
            {
                RenderOpretRediger(-1);
            }
            else if (Convert.ToInt32(Request.QueryString["rediger"]) > 0)
            {
                RenderOpretRediger(Convert.ToInt32(Request.QueryString["rediger"]));
            }
            else if (Convert.ToInt32(Request.QueryString["slet"]) > 0)
            {
                RenderSlet();
            }
            else if (Convert.ToInt32(Request.QueryString["post"]) > 0 && Convert.ToInt32(Request.QueryString["post"]) <= 3)
            {

                int? postMethod = (int?)Session["bolig_ros_post"];
                bolig sessionBolig = (bolig)Session["bolig_ros_index"];

                if (postMethod == null || sessionBolig == null)
                {
                    Response.Redirect("Badrequest.aspx");
                }
                else
                {
                    if (postMethod == 1 || postMethod == 2)
                    {
                        sessionBolig.department = Convert.ToInt32(Request.QueryString["department"]);
                        sessionBolig.ac_expenses = Convert.ToDecimal(Request.QueryString["ac_expenses"]);
                        sessionBolig.monthly_price = Convert.ToDecimal(Request.QueryString["monthly_price"]);
                        sessionBolig.deposit = Convert.ToInt32(Request.QueryString["deposit"]);
                        sessionBolig.rooms = Convert.ToInt32(Request.QueryString["rooms"]);
                        sessionBolig.persons = Convert.ToInt32(Request.QueryString["persons"]);
                        sessionBolig.children = Convert.ToInt32(Request.QueryString["children"]);
                        sessionBolig.dog_amount = Convert.ToInt32(Request.QueryString["dogs"]);
                        sessionBolig.cat_amount = Convert.ToInt32(Request.QueryString["cats"]);
                        sessionBolig.small_pets_amount = Convert.ToInt32(Request.QueryString["small_pets"]);
                        sessionBolig.kitchen = Convert.ToInt32(Request.QueryString["kitchen"]);
                        sessionBolig.bath = Convert.ToInt32(Request.QueryString["bath"]);
                        sessionBolig.area = Convert.ToInt32(Request.QueryString["area"]);
                        sessionBolig.surfacearea = Convert.ToInt32(Request.QueryString["surfacearea"]);
                        sessionBolig.description_dk = Request.QueryString["surfacearea"];
                        sessionBolig.description_en = Request.QueryString["surfacearea"];

                        if (postMethod == 1)
                        {
                            DB.AddToboligs(sessionBolig);
                        }

                        DB.SaveChanges();

                    }
                    else if (postMethod.Value == 3)
                    {
                        //Slet bolig
                    }
                }
            }
        }
        catch (NullReferenceException err)
        {
            Response.Redirect("Boliger.aspx");
        }
    }

    private void RenderOpretRediger(int index)
    {
        int? department = null;
        string description_dk = null;
        string description_en = null;
        int? area = null;
        int? rooms = null;
        decimal? surfacearea = null;
        int? persons = null;
        bool? children = null;
        int? dogs = null;
        int? cats = null;
        int? small_pets = null;
        bool? bath = null;
        bool? kitchen = null;
        decimal? monthly_price = null;
        decimal? ac_expenses = null;
        decimal? deposit = null;

        if (index >= 0)
        {
            var boliger = from b in DB.boligs where b.id == index select b;

            if (boliger.First() != null)
            {
                var bolig = boliger.First();

                Session.Add("bolig", bolig);

                department = bolig.department;
                area = bolig.area;
                surfacearea = bolig.surfacearea;
                rooms = bolig.rooms;
                description_dk = bolig.description_dk;
                description_en = bolig.description_en;
                bath = (bolig.bath == 1);
                kitchen = (bolig.kitchen == 1);
                persons = bolig.persons;
                children = (bolig.children == 1);
                cats = bolig.cat_amount;
                dogs = bolig.dog_amount;
                small_pets = bolig.small_pets_amount;
                monthly_price = bolig.monthly_price;
                ac_expenses = bolig.ac_expenses;
                deposit = bolig.deposit;
            }
        }

        if (department == null)
        {
            Session.Add("bolig", new bolig());

            area = 0;
            surfacearea = 0;
            rooms = 0;
            description_dk = "";
            description_en = "";
            bath = false;
            kitchen = false;
            children = false;
            persons = 0;
            cats = 0;
            dogs = 0;
            small_pets = 0;
            monthly_price = 0;
            ac_expenses = 0;
            deposit = 0;
        }

        string page = "";

        page += "Afdeling:<br /><select name=\"department\">";

        var temp = from t in DB.departments select t;

        foreach (var t in temp)
        {
            page += "<option value=\"" + t.id + " " + ((t.id == department && department != null) ? "selected=\"selected\"" : "") + "\">" + t.name + "</option>";
        }

        page += "</select><br /><br />";

        page += "Område:<br /><input type=\"text\" name=\"area\" value=\"" + area + "\" /><br />";

        page += "Kvm:<br /><input type=\"text\" name=\"area\" value=\"" + surfacearea + "\" /><br />";

        page += "Antal værelse:<br /><input type=\"text\" name=\"rooms\" value=\"" + rooms + "\" /><br />";

        page += "Antal personer:<br /><input type=\"text\" name=\"persons\" value=\"" + persons + "\" /><br />";

        page += "Børn:<br /><input type=\"checkbox\" name=\"children\" " + ((children == true) ? "checked=\"checked\"" : "") + " /><br />";

        page += "Antal katte:<br /><input type=\"text\" name=\"cats\" value=\"" + cats + "\" /><br />";

        page += "Antal hunde:<br /><input type=\"text\" name=\"dogs\" value=\"" + dogs + "\" /><br />";

        page += "Antal små kæledyr:<br /><input type=\"text\" name=\"small_pets\" value=\"" + small_pets + "\" /><br />";

        page += "Eget badeværelse:<br /><input type=\"checkbox\" name=\"bath\" " + ((bath == true) ? "checked=\"checked\"" : "") + " /><br />";

        page += "Eget køkken:<br /><input type=\"checkbox\" name=\"kitchen\" " + ((kitchen == true) ? "checked=\"checked\"" : "") + " /><br />";

        page += "Husleje:<br /><input type=\"text\" name=\"monthly_price\" value=\"" + monthly_price + "\" /><br />";

        page += "A/C udgifter:<br /><input type=\"text\" name=\"ac_expenses\" value=\"" + ac_expenses + "\" /><br />";

        page += "Depositum:<br /><input type=\"text\" name=\"deposit\" value=\"" + deposit + "\" /><br />";

        page += "Beskrivel(Dansk):<br /><textarea name=\"description_dk\"></textarea><br />";

        page += "Beskrivel(Engelsk):<br /><textarea name=\"description_en\"></textarea><br />";

        page += "<input type=\"submit\" />";

        RosBolig.Controls.Add(new Literal() { Text = page });
    }

    private void RenderSlet()
    {
        RosBolig.Controls.Add(new Literal() { Text = "lol" });
    }
}
