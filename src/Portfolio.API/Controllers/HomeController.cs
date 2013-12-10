using System.Web.Mvc;

namespace Portfolio.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}