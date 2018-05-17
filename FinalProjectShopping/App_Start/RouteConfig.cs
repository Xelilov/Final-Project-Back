using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinalProjectShopping
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "getSizeCount",
                url: "{controller}/{action}/{img_id}/{size_id}",
                defaults: new { controller = "Home", action = "getSizeCount" }
            );
            //routes.MapRoute(
            //    name: "Minprice",
            //    url: "{controller}/{action}/{minprice}/{innerid}",
            //    defaults: new { controller = "Home", action = "Minprice" }
            //);
        }
    }
}
