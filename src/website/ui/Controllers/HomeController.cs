using System.Web.Mvc;

namespace Dade.Dms.Website.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}