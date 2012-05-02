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
    int page_id = 1;
    tempdbEntities DB = new tempdbEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        

        RenderNews(EditPageID());
    }

    private void RenderNews(int editStoryNo)
    {
        var tekster = fetchAllTekstsFromDB(page_id);
        foreach (tekst t in tekster)
        {
            if (editStoryNo == t.id)
            {
                EditorControl OControl = (EditorControl)LoadControl("~/Controls/EditorControl.ascx");
                OControl.Text = t;
                NewsContent.Controls.Add(OControl);
            }
            else
            {
                RenderControl OControl = (RenderControl)LoadControl("~/Controls/RenderControl.ascx");
                OControl.Text = t;
                user u = ((user)Session["user"]);
                OControl.canEdit = (u != null && u.userlevel <= 2) ? true : false;
                NewsContent.Controls.Add(OControl);
            }
            
        }
    }

    private IEnumerable<tekst> fetchAllTekstsFromDB(int page_id)
    {
        return from t in DB.teksts where t.side_id == page_id select t;
    }
    private int EditPageID()
    {
        string id_req = Request.QueryString["edit"];
        int page_id = Convert.ToInt32(id_req ?? "-1");
        return page_id;
    }
}