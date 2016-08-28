using System;
using System.Linq;

using Petecat.Caching;
using Petecat.Extension;

using Dade.Dms.Website.Routing.Configuration;

namespace Dade.Dms.Website.Routing
{
    public class RouteManager
    {
        public const string CacheObjectName = "DMS_GlobalRoute";

        private static RouteManager _Instance = null;

        public static RouteManager Instance { get { return _Instance ?? (_Instance = new RouteManager()); } }

        public RouteManager()
        {
            if (string.IsNullOrEmpty("./Configuration/GlobalRoute.config".FullPath()))
            {
                throw new Exception("global route config file is missing.");
            }

            CacheObjectManager.Instance.AddXml<GlobalRouteConfig>(CacheObjectName, "./Configuration/GlobalRoute.config".FullPath(), true);
        }

        public UnitRouteConfig GetUnitRoute(string host)
        {
            if (UrlHelper.IsIpHost(host))
            {
                return CacheObjectManager.Instance.GetValue<GlobalRouteConfig>(CacheObjectName)
                    .UnitRoutes.FirstOrDefault(x => x.Domains != null
                    && x.Domains.ToList().Exists(y => host.Equals(y.Value, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                return CacheObjectManager.Instance.GetValue<GlobalRouteConfig>(CacheObjectName)
                    .UnitRoutes.FirstOrDefault(x => x.Domains != null 
                    && x.Domains.ToList().Exists(y => host.EndsWith(y.Value, StringComparison.OrdinalIgnoreCase)));
            }
        }

        public bool TryGetUnitRoute(string host, out DomainConfig domain, out UnitRouteConfig unitRoute)
        {
            if (UrlHelper.IsIpHost(host))
            {
                foreach (var unit in CacheObjectManager.Instance.GetValue<GlobalRouteConfig>(CacheObjectName)
                    .UnitRoutes.Where(x => x.Domains != null && x.Domains.Length > 0))
                {
                    var d = unit.Domains.FirstOrDefault(x => host.Equals(x.Value, StringComparison.OrdinalIgnoreCase));
                    if (d != null)
                    {
                        domain = d;
                        unitRoute = unit;
                        return true;
                    }
                }
            }
            else 
            {
                foreach (var unit in CacheObjectManager.Instance.GetValue<GlobalRouteConfig>(CacheObjectName)
                    .UnitRoutes.Where(x => x.Domains != null && x.Domains.Length > 0))
                {
                    var d = unit.Domains.FirstOrDefault(x => host.EndsWith(x.Value, StringComparison.OrdinalIgnoreCase));
                    if (d != null)
                    {
                        domain = d;
                        unitRoute = unit;
                        return true;
                    }
                }
            }

            domain = null;
            unitRoute = null;
            return false;
        }
    }
}