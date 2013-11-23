using System.Web.Mvc;
using System.Web.Routing;
using Portfolio.Lib;

namespace Portfolio.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            new ResourceRouteConfiguration(routes, "Tasks").Configure();
            new ResourceRouteConfiguration(routes, "Tags", settings: new ResourceRouteConfigurationSettings { IncludeShowAction = false }).Configure();
            
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}