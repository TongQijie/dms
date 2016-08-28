using Dade.Dms.Website.Routing;

using System.Web.Mvc;
using System.Web.Routing;

namespace Dade.Dms.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
