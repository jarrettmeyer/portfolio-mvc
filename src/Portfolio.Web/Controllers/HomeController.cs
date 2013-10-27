using System.Web.Mvc;
using Portfolio.Web.Lib;
using Portfolio.Web.Lib.Actions;

namespace Portfolio.Web.Controllers
{
    public class HomeController : ApplicationController
    {
        private readonly ActionResolver actionResolver;

        public HomeController(ActionResolver actionResolver)
        {
            this.actionResolver = actionResolver;
        }

        public ActionResult Index()
        {
            return actionResolver.GetAction<RedirectToListTasks>();            
        }

    }
}
