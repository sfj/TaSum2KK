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
            overskrift.InnerHtml = Text.id.ToString();
        }

        protected void EditButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("Forside.aspx?edit=" + Text.id);
        }
    }
}