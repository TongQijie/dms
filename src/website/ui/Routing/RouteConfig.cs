﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Dade.Dms.Website.Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add(new MvcDomainRoute());
        }
    }
}
