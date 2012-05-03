using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using System.Diagnostics;

public partial class NewsEditorControl : UserControl {
	public nyhed Text { get; set; }
    private Entities DB = DataAccess.getDataAccess().DB;

	protected override void OnLoad(EventArgs e) {
		
	}

	protected override void OnPreRender(EventArgs e) {
        if (Text != null)
        {
            NewsEditorHead.Value = Text.headline_dk;
            NewsEditor.Value = Text.text_dk;
        }
        else
        {
            NewsEditorHead.Value = "";
            NewsEditor.Value = "";
        }
	}

	protected void SubmitButton_Click(object sender, EventArgs e) {
        nyhed po;
        if (Text != null)
        {
            po = (from t in DB.nyheds where t.id == Text.id select t).SingleOrDefault();
        }
        else
        {
            po = new nyhed();
            po.created = new DateTime();
            DB.nyheds.AddObject(po);
        }
        po.text_dk = NewsEditor.Value;
        po.headline_dk = NewsEditorHead.Value;
        DB.SaveChanges();
        Text = po;
        Response.Redirect(Request.RawUrl);
	}
}