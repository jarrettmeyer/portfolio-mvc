using System.Web.Mvc;

namespace Portfolio.Web.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
