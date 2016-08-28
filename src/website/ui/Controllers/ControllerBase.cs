using Dade.Dms.Website.Routing.Configuration;

using System.Web.Mvc;

namespace Dade.Dms.Website.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public ControllerBase()
        {
            ViewData["controller"] = this;
        }

        public string Unit
        {
            get
            {
                return RouteData.Values["unit"] as string;
            }
        }

        public DomainConfig Domain
        {
            get
            {
                return RouteData.Values["domain"] as DomainConfig;
            }
        }

        public string ControllerName
        {
            get
            {
                return RouteData.Values["controller"] as string;
            }
        }

        public string ActionName
        {
            get
            {
                return RouteData.Values["action"] as string;
            }
        }

        public string[] Parameters
        {
            get
            {
                return RouteData.Values["parameters"] as string[] ?? new string[0];
            }
        }

        public string ControllerUrl
        {
            get
            {
                var host = HttpContext.Request.Headers["Host"];

                if (Domain.EnableSubdomain)
                {
                    return ControllerName + "." + Domain.Value;
                }
                else
                {
                    return Domain.Value + "/" + ControllerName;
                }
            }
        }
    }
}