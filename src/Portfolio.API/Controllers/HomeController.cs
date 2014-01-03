using System.Web.Mvc;

namespace Portfolio.API.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This is the only action in the application that returns
        /// a view result. All other. results will be from the API.
        /// </summary>
        /// <returns>Action result.</returns>
        public ActionResult Index()
        {
            return View("Index");
        }
	}
}