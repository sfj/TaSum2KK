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
        public nyhed Text { get; set; }
        public bool canEdit;

        private Entities DB = DataAccess.getDataAccess().DB;

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
            overskrift.InnerHtml = Text.headline_dk;
        }

        protected void EditButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("Forside.aspx?edit=" + Text.id);
        }

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            var post = (from p in DB.nyheds where p.id == Text.id select p).SingleOrDefault();
            DB.DeleteObject(post);
            DB.SaveChanges();
            Response.Redirect("Forside.aspx?edit=" + Text.id);
        }
    }
}