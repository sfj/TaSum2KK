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
    public partial class OpretRedigerBoligControl : System.Web.UI.UserControl
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
            departments.Multiple = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            bolig temp = (bolig)Session["bolig"];
            int? method = (int?)Session["ros_bolig"];
            if (method != null && method == 1)
            {
                OpretRedigerTable.Visible = true;
                SletBoligTable.Visible = false;
            }
            else if (method != null && method == 2)
            {
                OpretRedigerTable.Visible = true;
                SletBoligTable.Visible = false;

                ac_expenses.Value = temp.ac_expenses.ToString();
                area.Value = temp.area.ToString();
                bath.Checked = temp.bath == 1;
                cats.Value = temp.cat_amount.ToString();
                children.Checked = temp.children == 1;
                deposit.Value = temp.deposit.ToString();
                description_dk.Value = temp.description_dk;
                description_en.Value = temp.description_en;
                dogs.Value = temp.dog_amount.ToString();
                kitchen.Checked = temp.kitchen == 1;
                monthly_price.Value = temp.monthly_price.ToString();
                persons.Value = temp.persons.ToString();
                rooms.Value = temp.rooms.ToString();
                small_pets.Value = temp.small_pets_amount.ToString();
                surfacearea.Value = temp.surfacearea.ToString();
            }
            else if (method != null && method == 3)
            {
                OpretRedigerTable.Visible = false;
                SletBoligTable.Visible = true;

                ACExpensesLabel.Text = temp.ac_expenses.ToString();
                AreaLabel.Text = temp.area.ToString();
//                temp.bath.ToString();
//                temp.cat_amount.ToString();
//                temp.children.ToString();
                DepartmentLabel.Text = temp.department1.name;
                DepositLabel.Text = temp.deposit.ToString();
                DescriptionLabel.Text = temp.description_dk.ToString();
//                temp.description_en.ToString();
//                temp.dog_amount.ToString();
//                temp.kitchen.ToString();
                MonthlyPriceLabel.Text = temp.monthly_price.ToString();
//                temp.persons.ToString();
//                temp.rooms.ToString();
//                temp.small_pets_amount.ToString();
//                temp.surfacearea.ToString();

                TotalLabel.Text = (temp.ac_expenses + temp.monthly_price).ToString();

                derp.Text = "Slet";
            }
        }

        protected void derp_OnClick(object sender, EventArgs e)
        {
            bolig b = (bolig)Session["bolig"];
            int? method = (int?)Session["ros_bolig"];

            Console.WriteLine("Herp that derp");
            Console.WriteLine("" + method);

            if (method != null && method == 1)
            {
                b = DB.boligs.CreateObject();
                DB.boligs.AddObject(b);
            }

            if (method != null && (method == 1 || method == 2))
            {
                b.ac_expenses = Convert.ToDecimal(ac_expenses.Value);
                b.area = Convert.ToInt32(area.Value);
                b.bath = (bath.Checked) ? 1 : 0;
                b.cat_amount = Convert.ToInt32(cats.Value);
                b.children = (children.Checked) ? 1 : 0;
                b.department = (from temp in DB.departments where departments.Value == temp.name select temp).First().id;
                b.deposit = Convert.ToDecimal(deposit.Value);
                b.description_dk = description_dk.Value;
                b.description_en = description_en.Value;
                b.dog_amount = Convert.ToInt32(dogs.Value);
                b.kitchen = (kitchen.Checked) ? 1 : 0;
                b.monthly_price = Convert.ToDecimal(monthly_price.Value);
                b.persons = Convert.ToInt32(persons.Value);
                b.rooms = Convert.ToInt32(rooms.Value);
                b.small_pets_amount = Convert.ToInt32(small_pets.Value);
                b.surfacearea = Convert.ToDecimal(surfacearea.Value);
            } else if(method != null && method == 3)
            {
                DB.boligs.DeleteObject(b);
            }

            DB.SaveChanges();


            Session.Remove("bolig");
            Session.Remove("ros_bolig");

            Response.Redirect("Boliger.aspx");
        }
    }
}