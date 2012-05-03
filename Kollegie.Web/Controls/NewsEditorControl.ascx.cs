using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using System.Diagnostics;

public partial class NewsEditorControl : UserControl {
	public tekst Text { get; set; }
	private tempdbEntities DB = new tempdbEntities();

	protected override void OnLoad(EventArgs e) {
		
	}

	protected override void OnPreRender(EventArgs e) {
        NewsEditor.Value = Text.text_dk;
	}

	protected void SubmitButton_Click(object sender, EventArgs e) {		
		tekst po = (from t in DB.teksts where t.side_id == Text.side_id && t.id == Text.id select t).SingleOrDefault();		
		po.text_dk = NewsEditor.Value;
		DB.SaveChanges();
		Text = po;
	}
}