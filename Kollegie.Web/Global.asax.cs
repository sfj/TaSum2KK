using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Kollegie.Model;
using System.Diagnostics;

namespace Kollegie.Web {
	public class Global : System.Web.HttpApplication {

		protected void Application_Start(object sender, EventArgs e) {

		}

		protected void Session_Start(object sender, EventArgs e) {			
			if (User.Identity.IsAuthenticated && Session["user"] == null) {				
				HttpCookie OCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
				if (OCookie != null) {					
					FormsAuthenticationTicket OTicket = FormsAuthentication.Decrypt(OCookie.Value);
					tempdbEntities DB = new tempdbEntities();
					user user = (from u in DB.users where u.username == OTicket.Name select u).SingleOrDefault();
					if (user != null) {
						Session["user"] = user;
					}
				}
			}
		}

		protected void Application_BeginRequest(object sender, EventArgs e) {

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) {
			
		}

		protected void Application_Error(object sender, EventArgs e) {

		}

		protected void Session_End(object sender, EventArgs e) {

		}

		protected void Application_End(object sender, EventArgs e) {

		}
	}
}