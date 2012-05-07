using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using System.Diagnostics;

public partial class NewsEditorControl : UserControl
{
    public nyhed Text { get; set; }
    private Entities DB = DataAccess.getDataAccess().DB;

    protected override void OnLoad(EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (Text != null)
        {
            NewsEditorHead.Value = Text.headline_dk;
            NewsEditor.Value = Text.text_dk;
            HideButton.Text = (Text.hidden != true) ? "Skjul" : "Vis";
        }
        else
        {
            NewsEditorHead.Value = "";
            NewsEditor.Value = "";
            HideButton.Visible = false;
        }
    }

    protected void SubmitButtonClick(object sender, EventArgs e)
    {
        nyhed ny = GetNyhed();
        ny.text_dk = NewsEditor.Value;
        ny.headline_dk = NewsEditorHead.Value;
        DB.SaveChanges();
        Text = ny;
        Response.Redirect(Request.RawUrl);
    }
    protected void HideButtonClick(object sender, EventArgs e)
    {
        nyhed ny = GetNyhed();
        if (ny.hidden != null)
            ny.hidden = !ny.hidden;
        else
        {
            ny.hidden = true;
        }
        DB.SaveChanges();
    }
    private nyhed GetNyhed()
    {
        nyhed po;
        if (Text != null)
        {
            po = (from t in DB.nyheds where t.id == Text.id select t).SingleOrDefault();
        }
        else
        {
            po = new nyhed();
            po.created = DateTime.Today;
            DB.nyheds.AddObject(po);
        }
        return po;
    }
}