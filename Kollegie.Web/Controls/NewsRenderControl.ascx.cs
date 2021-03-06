﻿using System;
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

        private Entities DB = Global.DB;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (canEdit)
            {
                EditButton.Visible = true;
            }
            broedtekst.InnerHtml = ((string)Session["lang"]) == "da" ? Text.text_dk : Text.text_en;
            dato.InnerHtml = ((DateTime)Text.created).ToShortDateString();
            overskrift.InnerHtml = (Text.hidden == true) ? "<em>(Skjult)</em> " : "";
            overskrift.InnerHtml += ((string)Session["lang"]) == "da" ? Text.headline_dk : Text.headline_en;
        }

        protected void EditButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("Forside.aspx?edit=" + Text.id);
        }
    }
}