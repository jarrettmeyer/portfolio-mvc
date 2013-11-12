using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio.Lib
{
    public class ResourceRouteConfig
    {
        public static void Apply(RouteCollection routes, string controllerName, string resource = null)
        {
            if (resource == null)
                resource = controllerName.ToLowerInvariant();

            routes.MapRoute(controllerName + "-Index", resource, 
                new { controller = controllerName, action = "Index" });
            routes.MapRoute(controllerName + "-New", resource + "/new",
                new { controller = controllerName, action = "New"});
            routes.MapRoute(controllerName + "-Show", resource + "/{id}", 
                new { controller = controllerName, action = "Show" }, 
                new { id = @"\d+" });
            routes.MapRoute(controllerName + "-Edit", resource + "/{id}/edit", 
                new { controller = controllerName, action = "Edit" }, 
                new { id = @"\d+" });
            routes.MapRoute(controllerName + "-Delete", resource + "/{id}/delete", 
                new { controller = controllerName, action = "Show" }, 
                new { id = @"\d+", method = new HttpMethodConstraint("DELETE") });
        }
    }
}