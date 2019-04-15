﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DRC", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                     name: "DefaultWebApi",
                    url: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                     );
        }
    }
}