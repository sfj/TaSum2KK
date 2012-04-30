using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tempdbModel;

public partial class Tekstside : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tempdbEntities DB = new tempdbEntities();
        string id_req = Request.QueryString["id"];
        int page_id = Convert.ToInt32(id_req);
        text1.Controls.Add(new Literal()
        {
            Text = (from t in DB.teksts where t.side_id == page_id select t.text_dk).SingleOrDefault()
        });
    }
}