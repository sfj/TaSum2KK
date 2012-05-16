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

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);

            departments.Items.Add("Alle afdelinger");


            foreach (var b in DB.departments) {
                departments.Items.Add(b.name);
            }

            departments.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            derp.Text = ((string)Session["lang"]) == "en" ? "Search" : "Søg" ;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bolig bolig_search = (bolig)Session["search_result"];

            if (bolig_search != null) {
                area.Value = bolig_search.area != -1 ? bolig_search.area.ToString() : "";
                bath.Checked = bolig_search.bath != 0 ? bolig_search.bath == 1 : false;
                cats.Value = bolig_search.cat_amount != -1 ? bolig_search.cat_amount.ToString() : "";
                children.Checked = bolig_search.children != 0 ? bolig_search.children == 1 : false;
                description_dk.Value = bolig_search.description_dk;
                dogs.Value = bolig_search.dog_amount != -1 ? bolig_search.dog_amount.ToString() : "";
                kitchen.Checked = bolig_search.kitchen != 0 ? bolig_search.kitchen == 1 : false;
                monthly_price.Value = bolig_search.monthly_price != -1 ? bolig_search.monthly_price.ToString() : "";
                rooms.Value = bolig_search.rooms != -1 ? bolig_search.rooms.ToString() : "";
                small_pets.Value = bolig_search.small_pets_amount != -1 ? bolig_search.small_pets_amount.ToString() : "";
                surfacearea.Value = bolig_search.surfacearea != -1 ? bolig_search.surfacearea.ToString() : "";
            }

            area.Multiple = true;
            departments.Multiple = true;
        }

        protected void derp_OnClick(object sender, EventArgs e)
        {
            bolig b = new bolig();

            int selected_department = -1;
            if (departments.SelectedIndex > 0)
            {
                selected_department = (from temp in DB.departments where departments.Value == temp.name select temp).SingleOrDefault().id;
            }

            b.bath = (bath.Checked) ? 1 : 0;
            b.cat_amount = cats.Value != "" ? Convert.ToInt32(cats.Value) : -1;
            b.children = (children.Checked) ? 1 : 0;
            b.department = selected_department;
            b.description_dk = description_dk.Value != "" ? description_dk.Value : null;
            b.dog_amount = dogs.Value != "" ? Convert.ToInt32(dogs.Value) : -1;
            b.persons = persons.Value != "" ? Convert.ToInt32(persons.Value) : -1;
            b.kitchen = (kitchen.Checked) ? 1 : 0;
            b.monthly_price = monthly_price.Value != "" ? Convert.ToDecimal(monthly_price.Value) : -1;
            b.rooms = rooms.Value != "" ? Convert.ToInt32(rooms.Value) : -1;
            b.small_pets_amount = small_pets.Value != "" ? Convert.ToInt32(small_pets.Value) : -1;
            b.surfacearea = surfacearea.Value != "" ? Convert.ToDecimal(surfacearea.Value) : -1;

            Session["search_result"] = b;

            Response.Redirect("Boliger.aspx");
        }
    }
}