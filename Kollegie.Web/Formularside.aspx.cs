using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Web.Controls;

namespace Kollegie.Web {
    public partial class Formularside : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            SearchBoligControl sbc = (SearchBoligControl)LoadControl("~/Controls/SearchBoligControl.ascx");
            search_form.Controls.Add(sbc);
        }
    }
}