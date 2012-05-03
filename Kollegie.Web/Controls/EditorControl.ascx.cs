using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using System.Diagnostics;

public partial class EditorControl : UserControl {
	public tekst Text { get; set; }
    private Entities DB = DataAccess.getDataAccess().DB;

	protected override void OnLoad(EventArgs e) {
		Page.ClientScript.RegisterClientScriptBlock(typeof(EditorControl), "CopyValue", "function CopyValue() { document.getElementById('" + EditorValue.ClientID + "').value = document.getElementById('" + Editor.ClientID + "').innerHTML; }", true);
		SubmitButton.OnClientClick = "CopyValue();";
	}

	protected override void OnPreRender(EventArgs e) {		
		Editor.InnerHtml = Text.text_dk;
	}

	protected void SubmitButton_Click(object sender, EventArgs e) {		
		tekst po = (from t in DB.teksts where t.side_id == Text.side_id && t.id == Text.id select t).SingleOrDefault();		
		po.text_dk = EditorValue.Value;
		DB.SaveChanges();
		Text = po;
	}
}