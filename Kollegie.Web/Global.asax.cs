﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Kollegie.Model;
using System.Diagnostics;

namespace Kollegie.Web {
	public class Global : System.Web.HttpApplication {

        private static Entities db;

        public static Entities DB
        {
            get { return Global.db; }
            set { Global.db = value; }
        }

		protected void Application_Start(object sender, EventArgs e) {
            DB = DataAccess.getDataAccess(HttpContext.Current.Server.MapPath(null)).DB;      
		}

		protected void Session_Start(object sender, EventArgs e) {
            if (User.Identity.IsAuthenticated && Session["user"] == null) {				
				HttpCookie OCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
				if (OCookie != null) {					
					FormsAuthenticationTicket OTicket = FormsAuthentication.Decrypt(OCookie.Value);
                    Entities DB = DataAccess.getDataAccess(HttpContext.Current.Server.MapPath(null)).DB;
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
            db.Dispose();
		}
	}
}