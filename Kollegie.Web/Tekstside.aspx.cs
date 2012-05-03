using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using Kollegie.Model;

public partial class Tekstside : System.Web.UI.Page {
    private Entities DB = DataAccess.getDataAccess().DB;

	protected void Page_Load(object sender, EventArgs e) {
		if (Request.QueryString.Count < 1) {
			Response.Redirect("BadRequest.aspx");
		}

		user u = ((user)Session["user"]);
		if (u != null && u.userlevel <= 2) {
			VisEditor();
		}
		else {
			VisTekst();
		}
	}

	private int PageID() {
		string id_req = Request.QueryString["id"];
		int page_id = Convert.ToInt32(id_req);
		return page_id;
	}

	private void VisEditor() {
		EditorControl OControl = (EditorControl)LoadControl("~/Controls/EditorControl.ascx");
		OControl.Text = fetchOneTekstFromDB(PageID());
		ContentPlaceHolder.Controls.Add(OControl);
	}

	private void VisTekst() {
		ContentLabel.Text = fetchOneTekstFromDB(PageID()).text_dk;
	}

	private tekst fetchOneTekstFromDB(int id) {
		return (from t in DB.teksts where t.side_id == id select t).SingleOrDefault();
	}

	private IEnumerable<tekst> fetchAllTekstsFromDB(int page_id) {
		return from t in DB.teksts where t.side_id == page_id select t;
	}
}