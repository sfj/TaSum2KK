using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Kollegie.Web {
    /// <summary>
    /// Summary description for styles
    /// </summary>
    public class styles : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/css";
            string css = File.ReadAllText(context.Server.MapPath(context.Request.QueryString["p"]));

            css = css.Replace("<%=color0%>", "#ffffff");
            css = css.Replace("<%=color1%>", "#222222");
            css = css.Replace("<%=color2%>", "#f8f8f8");
            css = css.Replace("<%=color3%>", "#69bbda");
            css = css.Replace("<%=color4%>", "#444444");
            css = css.Replace("<%=color5%>", "#113f9f");
            css = css.Replace("<%=color6%>", "#66ccee");
            css = css.Replace("<%=color7%>", "#eeeeee");
            css = css.Replace("<%=color8%>", "#b8dff8");
            css = css.Replace("<%=color9%>", "#999999");

            context.Response.Write(css); 
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}