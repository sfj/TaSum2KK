using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;

namespace Kollegie.Web.Controls
{
    public partial class MenuPunktControl : System.Web.UI.UserControl
    {
        public menu punkt { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var subpunkter = from s in Global.DB.menus where s.level == 1 && s.parent == punkt.id select s;

            foreach (menu s in subpunkter) 
            {
                SubMenuPunktControl smpc = (SubMenuPunktControl)LoadControl("~/Controls/SubMenuPunktControl.ascx");
                smpc.punkt = s;
                sub.Controls.Add(smpc);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            mp.Attributes.Add("onMouseOver", "justshow(\'" + dd.ClientID + "\');");
            mp.Attributes.Add("onMouseOut", "justhide(\'" + dd.ClientID + "\');");

            Link.InnerText = ((string)Session["lang"]) == "da" ? punkt.text_dk : punkt.text_en;
            Link.HRef = "~/" + punkt.skabelon.filename + "?id=" + punkt.id;
        }
    }
}