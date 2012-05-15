using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kollegie.Model;

namespace Kollegie.Web.Controls
{
    public partial class SearchBoligControl : System.Web.UI.UserControl
    {
        private Entities DB = Global.DB;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            foreach (var b in DB.departments)
            {
                departments.Items.Add(b.name);
            }

            departments.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int? method = (int?) Session["bolig_ros"];

            if(method != null && method > 0)
            {
                var query = from b in DB.boligs where method == b.id select b;
                bolig temp = query.First();
                Session.Add("bolig", temp); 

                area.Value = temp.area.ToString();
                bath.Checked = temp.bath == 1;
                cats.Value = temp.cat_amount.ToString();
                children.Checked = temp.children == 1;
                description_dk.Value = temp.description_dk;
                dogs.Value = temp.dog_amount.ToString();
                kitchen.Checked = temp.kitchen == 1;
                monthly_price.Value = temp.monthly_price.ToString();
                rooms.Value = temp.rooms.ToString();
                small_pets.Value = temp.small_pets_amount.ToString();
                surfacearea.Value = temp.surfacearea.ToString();
            }
        }

        protected void derp_OnClick(object sender, EventArgs e)
        {
            bolig b = (bolig) Session["bolig"];

            bool opret = b == null;

            if(opret)
            {
                b = new bolig();
                DB.AddToboligs(b);
            }

            b.bath = (bath.Checked) ? 1 : 0;
            b.cat_amount = Convert.ToInt32(cats.Value);
            b.children = (children.Checked) ? 1 : 0;
            b.department = (from temp in DB.departments where departments.Value == temp.name select temp).First().id;
            b.description_dk = description_dk.Value;
            b.dog_amount = Convert.ToInt32(dogs.Value);
            b.kitchen = (kitchen.Checked) ? 1 : 0;
            b.monthly_price = Convert.ToDecimal(monthly_price.Value);
            b.rooms = Convert.ToInt32(rooms.Value);
            b.small_pets_amount = Convert.ToInt32(small_pets.Value);
            b.surfacearea = Convert.ToDecimal(surfacearea.Value);

            DB.SaveChanges();

            Response.Redirect("Boliger.aspx");
        }
    }
}