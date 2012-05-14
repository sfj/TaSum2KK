using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;
using System.Diagnostics;
using Kollegie.Web;

public partial class EditorControl : UserControl {
	public tekst Text { get; set; }
    private Entities DB = Global.DB;

	protected override void OnLoad(EventArgs e) {
		Page.ClientScript.RegisterClientScriptBlock(typeof(EditorControl), "CopyValue", "function CopyValue() { document.getElementById('" + EditorValue.ClientID + "').value = document.getElementById('" + Editor.ClientID + "').innerHTML; }", true);
		SubmitButton.OnClientClick = "CopyValue();";
	}

	protected override void OnPreRender(EventArgs e) {
        Editor.InnerHtml = ((String) Session["lang"] == "da") ? Text.text_dk : Text.text_en;
	}

	protected void SubmitButton_Click(object sender, EventArgs e) {		
		tekst po = (from t in DB.teksts where t.side_id == Text.side_id && t.id == Text.id select t).SingleOrDefault();		
		if ((String) Session["lang"] == "en")
		{
		   po.text_en = EditorValue.Value;  
		} 
        else
		{
		    po.text_dk = EditorValue.Value;
		}
		DB.SaveChanges();
		Text = po;
	}
}