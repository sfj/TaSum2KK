using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using Kollegie.Web;
using Kollegie.Web.Controls;

public partial class rosbolig : System.Web.UI.Page
{
    private Entities DB = Global.DB;

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
        OpretRedigerBoligControl ORControl = (OpretRedigerBoligControl)LoadControl("~/Controls/OpretRedigerBoligControl.ascx");
        Session.Add("bolig_ros", index);
        RosBolig.Controls.Add(ORControl);
    }

    private void RenderSlet()
    {
        RosBolig.Controls.Add(new Literal() { Text = "lol" });
    }
}
