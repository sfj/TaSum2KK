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
            }
            broedtekst.InnerHtml = Text.text_dk;
            dato.InnerHtml = ((DateTime)Text.created).ToShortDateString();
            overskrift.InnerHtml = Text.headline_dk;
        }

        protected void EditButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("Forside.aspx?edit=" + Text.id);
        }
    }
}