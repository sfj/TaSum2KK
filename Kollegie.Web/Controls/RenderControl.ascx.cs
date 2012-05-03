using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;

namespace Kollegie.Web.Controls
{
    public partial class RenderControl : System.Web.UI.UserControl
    {
        public tekst Text { get; set; }
        public bool canEdit;

        tempdbEntities DB = new tempdbEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (canEdit)
            {
                EditButton.Visible = true;
                DeleteButton.Visible = true;
            }
            broedtekst.InnerHtml = Text.text_dk;
            overskrift.InnerHtml = Text.id.ToString();
        }

        protected void EditButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("Forside.aspx?edit=" + Text.id);
        }

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            var post = (from p in DB.teksts where p.id == Text.id select p).SingleOrDefault();
            DB.DeleteObject(post);
            DB.SaveChanges();
            Response.Redirect("Forside.aspx?edit=" + Text.id);
        }
    }
}