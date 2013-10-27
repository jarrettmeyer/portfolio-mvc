using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio.Web.Lib.Actions
{
    public class RedirectToListTasks : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var routeValues = new RouteValueDictionary(new { controller = "Tasks", action = "Index" });
            var redirect = new RedirectToRouteResult(routeValues);
            redirect.ExecuteResult(context);
        }
    }
}