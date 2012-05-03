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
	private tempdbEntities DB = new tempdbEntities();

	protected override void OnLoad(EventArgs e) {
		
	}

	protected override void OnPreRender(EventArgs e) {
        if (Text != null)
        {
            NewsEditor.Value = Text.text_dk;
        }
        else
        {
            NewsEditor.Value = "";
        }
	}

	protected void SubmitButton_Click(object sender, EventArgs e) {
        if (Text != null)
        {
            nyhed po = (from t in DB.nyheds where t.id == Text.id select t).SingleOrDefault();
            po.text_dk = NewsEditor.Value;
            DB.SaveChanges();
            Text = po;
        }
        else
        {
            var po = DB.CreateObject<nyhed>();
            po.created = new DateTime();
            po.text_dk = NewsEditor.Value;
            DB.SaveChanges();
            Text = po;
        }
	}
}