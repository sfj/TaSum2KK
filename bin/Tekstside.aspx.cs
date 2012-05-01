using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tempdbModel;
using System.Web.UI.HtmlControls;

public partial class Tekstside : System.Web.UI.Page
{
    tempdbEntities DB = new tempdbEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        user u  = ((user)Session["user"]);
        if (u != null && u.userlevel <= 2)
        {
            RedigerTekst();            
        }
        else
        {
            VisTekst();
        }

        var post = Request.Form["editbox"];
        var post_id = Convert.ToInt32(Request.Form["hiddenid"]);

        tekst po = (from t in DB.teksts where t.side_id == PageID() && t.id == post_id select t).SingleOrDefault();

        po.text_dk = post;

        DB.SaveChanges();

        var div = text1.FindControl("box1") as HtmlGenericControl;
        var omgcake = div.InnerHtml;

        if(IsPostBack)
        {
            
        }

        
    }

    private void RedigerTekst()
    {
        int tekstID = fetchTekstFromDB(PageID()).id;
        var tag = new Literal()
        {
            Text = "<form id=\"editform\" action=\"?id=" + PageID() + "\" method=\"post\">"
            + "<input type=\"hidden\" name=\"hiddenid\" value=\"" + tekstID + "\" />"
            + "<div contenteditable=\"true\" id=\"box1\" name=\"editbox\" class=\"editing_box\">" + fetchTekstFromDB(PageID()).text_dk + " </div>"
            + "<input type=\"text\" name=\"editbox\" value=\"" + fetchTekstFromDB(PageID()).text_dk + "\" />"
            + "<input type=\"submit\" value=\"Gem\" onClick=\"document.forms['editform'].submit();\" />"
            + "</form>"
        };
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
        div.Attributes.Add("contenteditable","true");
        
        // text1.Controls.Add(tag);

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
            Text = fetchTekstFromDB(PageID()).text_dk + "lol"
        });
    }

    private tekst fetchTekstFromDB(int id)
    {
        return (from t in DB.teksts where t.side_id == id select t).SingleOrDefault();
    }
}