using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tempdbModel;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateMenu();
    }

    private void CreateMenu()
    {
        menuEntities DB = new menuEntities();

        var punkter = from p in DB.menus where p.level == 0 select p;

        foreach(menu p in punkter) {
            Literal td = new Literal();
            td.Text = "<td class=\"menupunkt\" onMouseOver=\"justshow('dd" + p.id + "');\" onMouseOut=\"justhide('dd" + p.id + "');\">";
            Menu.Controls.Add(td);

            HyperLink link = new HyperLink();
            link.CssClass = "menu_link";
            link.Text = p.text_dk;
            link.NavigateUrl = p.skabelon.filename;
            Menu.Controls.Add(link);

            Literal div = new Literal();
            div.Text = "<div class=\"dd_div\" id=\"dd" + p.id + "\">";
            Menu.Controls.Add(div);

            Table sub = new Table();
            sub.CssClass = "dropdown";
            sub.CellPadding = 0;
            sub.CellSpacing = 0;

            var subpunkter = from s in DB.menus where s.level == 1 && s.parent == p.id select s;

            foreach (menu s in subpunkter)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.CssClass = "dd_menupunkt";

                HyperLink sublink = new HyperLink();
                sublink.CssClass = "dd_menulink";

                sublink.Text = s.text_dk;
                sublink.NavigateUrl = s.skabelon.filename;

                cell.Controls.Add(sublink);
                row.Cells.Add(cell);
                sub.Rows.Add(row);
                System.Diagnostics.Debug.WriteLine("Row added");
            }
            Menu.Controls.Add(sub);

            Literal div_e = new Literal();
            div_e.Text = "</div>";
            Menu.Controls.Add(div_e);

            Literal td_e = new Literal();
            td_e.Text = "</td>";
            Menu.Controls.Add(td_e);
        }
    }
}
