using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library_Management_System
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Library",
                url: "library",
                defaults: new { controller = "Account", action = "Login"}
            );
            routes.MapRoute(
                name: "Library-login",
                url: "library/{Login}",
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "Admin-login",
                url: "admin/{Login}",
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
               name: "Account",
               url: "account",
               defaults: new { controller = "Account", action = "Login" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
