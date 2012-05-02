using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tempdbModel;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Tekstside : System.Web.UI.Page
{
    tempdbEntities DB = new tempdbEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count < 1)
        {
            Response.Redirect("BadRequest.aspx");
        }
        
        user u  = ((user)Session["user"]);
        if (u != null && u.userlevel <= 2)
        {
            RedigerTekst();            
        }
        else
        {
            VisTekst();
        }
        if (Request.Form.Count > 0) // ugly hax? checking if data is being submitted
        {
            // Non-working code block begin
            // Henter bare data allerede i div'et, ikke fra post'en.. ikke særlig brugbart
            //var post = Request.Form["editbox"];
            var form = text1.FindControl("editform") as HtmlForm;
            var hid = form.FindControl("hiddenid") as HiddenField;
            var post_id = Convert.ToInt32(hid.Value);

            var box = Request.Form["box1"];

            var div = form.FindControl("box1") as HtmlGenericControl;

            StringWriter sw = new StringWriter();
            HtmlTextWriter h = new HtmlTextWriter(sw);
            div.RenderControl(h);

            //var omgcake = div.InnerHtml;
            var omgcake = sw.GetStringBuilder().ToString();
            // Non working code block end
            
            var pid = PageID();
            tekst po = (from t in DB.teksts where t.side_id == pid && t.id == post_id select t).SingleOrDefault();

            //po.text_dk = post;
            po.text_dk = omgcake;

            System.Diagnostics.Debug.WriteLine("Saving: " + omgcake + ", On: " + pid + ", In: " + post_id);

            DB.SaveChanges();
        }

        if(IsPostBack)
        {
            
        }        
    }

    private void RedigerTekst()
    {
        int tekstID = fetchOneTekstFromDB(PageID()).id;
        //var tag = new Literal()
        //{
        //    Text = "<form id=\"editform\" action=\"?id=" + PageID() + "\" method=\"post\">"
        //    + "<input type=\"hidden\" name=\"hiddenid\" value=\"" + tekstID + "\" />"
        //    + "<div contenteditable=\"true\" id=\"box1\" name=\"editbox\" class=\"editing_box\">" + fetchTekstFromDB(PageID()).text_dk + " </div>"
        //    + "<input type=\"text\" name=\"editbox\" value=\"" + fetchTekstFromDB(PageID()).text_dk + "\" />"
        //    + "<input type=\"submit\" value=\"Gem\" onClick=\"document.forms['editform'].submit();\" />"
        //    + "</form>"
        //};
        // Nedenstående gør det samme som udkommenteret ovenfor, blot som hentbare elementer i text1.Controls
        HtmlForm form = new HtmlForm();
        form.ID = "editform";
        form.Action = "?id=" + PageID();
        form.Method = "Post";

        HiddenField hidden = new HiddenField();
        hidden.ID = "hiddenid";
        hidden.Value = "" + tekstID;
        form.Controls.Add(hidden);

        HtmlGenericControl div = new HtmlGenericControl();
        div.TagName = "div";
        div.Attributes.Add("contenteditable", "true");
        div.ID = "box1";
        div.Attributes.Add("class", "editing_box");
        div.InnerHtml = fetchOneTekstFromDB(PageID()).text_dk;
        form.Controls.Add(div);

        HiddenField hidden2 = new HiddenField();
        hidden2.ID = "text_commit";
        hidden2.Value = "";
        form.Controls.Add(hidden2);

        Button but = new Button();
        but.OnClientClick = "document.forms['editform'].submit();";
        but.Text = "Gem";
        but.UseSubmitBehavior = true;
        form.Controls.Add(but);

        text1.Controls.Add(form);

        //text1.Controls.Add(tag);

        //var div = text1.FindControl("box1") as HtmlGenericControl;
        //div.InnerHtml = "penis penis lol";
    }

    private int PageID()
    {
        string id_req = Request.QueryString["id"];
        int page_id = Convert.ToInt32(id_req);
        return page_id;
    }

    private void VisTekst()
    {        
        text1.Controls.Add(new Literal()
        {
            Text = fetchOneTekstFromDB(PageID()).text_dk
        });
    }

    private tekst fetchOneTekstFromDB(int id)
    {
        return (from t in DB.teksts where t.side_id == id select t).SingleOrDefault();
    }

    private IEnumerable<tekst> fetchAllTekstsFromDB(int page_id)
    {
        return from t in DB.teksts where t.side_id == page_id select t;
    }
}