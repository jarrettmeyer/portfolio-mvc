using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : ApplicationController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tasks");
        }

    }
}
