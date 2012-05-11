using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;

namespace Kollegie.Web.Controls
{
    public partial class SubMenuPunktControl : System.Web.UI.UserControl
    {
        public menu punkt { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            sublink.InnerText = ((string)Session["lang"]) == "da" ? punkt.text_dk : punkt.text_en;
            sublink.HRef = "~/" + punkt.skabelon.filename + "?id=" + punkt.id;
        }
        
    }
}