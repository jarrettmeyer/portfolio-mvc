using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio.API.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = true;
            routes.MapRoute("Home-Index", "index.html", new { controller = "Home", action = "Index" });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
    
}