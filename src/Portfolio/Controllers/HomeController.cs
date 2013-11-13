using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.Lib.Actions;

namespace Portfolio.Controllers
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
            var action = actionResolver.GetAction<RedirectToListTasks>();
            return new ActionResultWrapper(action);
        }

    }
}
