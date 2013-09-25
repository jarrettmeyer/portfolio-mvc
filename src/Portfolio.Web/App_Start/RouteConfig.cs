using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Tasks-Edit", "tasks/{id}/edit", new { controller = "Tasks", action = "Edit" }, new { id = @"\d+" });
            routes.MapRoute("Workflows-Show", "workflows/{status}", new { controller = "Workflows", action = "Show" }, new { status = "[a-zA-Z0-9]+" });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}