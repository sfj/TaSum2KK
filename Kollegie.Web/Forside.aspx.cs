using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using Kollegie.Web.Controls;

public partial class Forside : System.Web.UI.Page
{
    private Entities DB = DataAccess.getDataAccess().DB;

    protected void Page_Load(object sender, EventArgs e)
    {
        RenderNews(EditPageID());
    }

    private void RenderNews(int editStoryNo)
    {
        if (CanEditPage() && EditPageID() > -1)
        {
            NewsEditorControl OControl = (NewsEditorControl)LoadControl("~/Controls/NewsEditorControl.ascx");
            OControl.Text = null;
            NewsContent.Controls.Add(OControl);
        }

        var tekster = from t in DB.nyheds orderby t.created descending select t;
        foreach (var t in tekster)
        {
            if (editStoryNo == t.id)
            {
                NewsEditorControl OControl = (NewsEditorControl)LoadControl("~/Controls/NewsEditorControl.ascx");
                OControl.Text = t;
                NewsContent.Controls.Add(OControl);
            }
            else
            {
                RenderControl OControl = (RenderControl)LoadControl("~/Controls/RenderControl.ascx");
                OControl.Text = t;                
                OControl.canEdit = CanEditPage();
                NewsContent.Controls.Add(OControl);
            }
        }
    }

    private bool CanEditPage()
    {
        user u = ((user)Session["user"]);
        return (u != null && u.userlevel <= 2) ? true : false;
    }

    private int EditPageID()
    {
        string id_req = Request.QueryString["edit"];
        int page_id = Convert.ToInt32(id_req ?? "-1");
        return page_id;
    }
}