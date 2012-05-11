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
                if (Session["ros_bolig"] == null)
                {
                    Session.Add("ros_bolig", 1);
                }
                else
                {
                    Session["ros_bolig"] = 1;
                }
            }
            else if (Request.QueryString["rediger"] != null && Convert.ToInt32(Request.QueryString["rediger"]) > 0)
            {
                int? rediger = Convert.ToInt32(Request.QueryString["rediger"]);

                if (Session["ros_bolig"] == null)
                {
                    Session.Add("ros_bolig", 2);
                }
                else
                {
                    Session["ros_bolig"] = 2;
                }

                var temp = from b in DB.boligs where b.id == rediger select b;

                bolig bTemp = temp.First();

                if (Session["bolig"] == null)
                {
                    Session.Add("bolig", bTemp);
                }
                else
                {
                    Session["bolig"] = bTemp;
                }

            }
            else if (Request.QueryString["slet"] != null && Convert.ToInt32(Request.QueryString["slet"]) > 0)
            {
                int? slet = Convert.ToInt32(Request.QueryString["slet"]);

                if (Session["ros_bolig"] == null)
                {
                    Session.Add("ros_bolig", 3);
                } else
                {
                    Session["ros_bolig"] = 3;
                }

                var temp = from b in DB.boligs where b.id == slet select b;

                bolig bTemp = temp.First();

                if (Session["bolig"] == null)
                {
                    Session.Add("bolig", bTemp);
                }
                else
                {
                    Session["bolig"] = bTemp;
                }
            }
            OpretRedigerBoligControl ORControl = (OpretRedigerBoligControl)LoadControl("~/Controls/OpretRedigerBoligControl.ascx");
            RosBolig.Controls.Add(ORControl);
        }
        catch (NullReferenceException err)
        {
            Response.Redirect("Boliger.aspx");
        }
    }

    private void RenderOpretRediger(int index)
    {
        Session.Add("bolig_ros", index);
    }

    private void RenderSlet()
    {
        RosBolig.Controls.Add(new Literal() { Text = "lol" });
    }
}
