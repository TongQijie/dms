using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Dade.Dms.Website.Routing.Configuration;

namespace Dade.Dms.Website.Routing
{
    /// <summary>
    /// Mvc domain route.
    /// http://domain/controller/action/parameters
    /// http://controller.domain/action/parameters
    /// http://action.controller.domain/parameters
    /// http://ip/controllers/action/parameters
    /// </summary>
    public class MvcDomainRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var host = httpContext.Request.Headers["Host"];

            if (UrlHelper.IsIpHost(host))
            {
                UnitRouteConfig unitRoute;
                DomainConfig domain;
                if (!RouteManager.Instance.TryGetUnitRoute(host, out domain, out unitRoute))
                {
                    return null;
                }

                var stack = httpContext.Request.Url.LocalPath.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToList();

                return GetRouteData(unitRoute, domain, stack);
            }
            else 
            {
                UnitRouteConfig unitRoute;
                DomainConfig domain;
                if (!RouteManager.Instance.TryGetUnitRoute(host, out domain, out unitRoute))
                {
                    return null;
                }

                var stack = host.Substring(0, host.Length - domain.Value.Length).Split('.').Where(x => !string.IsNullOrEmpty(x)).Reverse().ToList();

                stack.AddRange(httpContext.Request.Url.LocalPath.Split('/').Where(x => !string.IsNullOrEmpty(x)));

                return GetRouteData(unitRoute, domain, stack);
            }
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            throw new NotImplementedException();
        }

        private RouteData GetRouteData(UnitRouteConfig unitRoute, DomainConfig domain, List<string> stack)
        {
            var routeData = new RouteData(this, new MvcRouteHandler());

            ControllerRouteConfig controller = null;

            if (stack.Count == 0)
            {
                controller = unitRoute.ControllerRoutes.FirstOrDefault(x => x.IsDefault);
            }
            else
            {
                controller = unitRoute.ControllerRoutes.FirstOrDefault(x => x.Name.Equals(stack[0], StringComparison.OrdinalIgnoreCase));
            }

            if (controller == null)
            {
                return null;
            }

            ActionRouteConfig action = null;

            if (stack.Count <= 1)
            {
                action = controller.ActionRoutes.FirstOrDefault(x => x.IsDefault);
            }
            else
            {
                action = controller.ActionRoutes.FirstOrDefault(x => x.Readable.Equals(stack[1], StringComparison.OrdinalIgnoreCase));
            }

            if (action == null)
            {
                return null;
            }

            routeData.Values.Add("unit", unitRoute.Name);
            routeData.Values.Add("domain", domain);
            routeData.Values.Add("controller", controller.Name);
            routeData.Values.Add("action", action.Name);
            routeData.Values.Add("parameters", stack.Skip(2).ToArray());

            return routeData;
        }
    }
}