using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio.Lib
{
    public class ResourceRouteConfiguration
    {
        private readonly string controllerName;
        private readonly string resourceName;
        private readonly RouteCollection routes;
        private readonly ResourceRouteConfigurationSettings settings;

        public ResourceRouteConfiguration(RouteCollection routes, string resourceName, string controllerName = null, ResourceRouteConfigurationSettings settings = null)
        {
            this.routes = routes;
            this.resourceName = resourceName;
            this.controllerName = controllerName ?? resourceName;

            // If no settings object was passed in the constructor, then use the default settings.
            this.settings = settings ?? new ResourceRouteConfigurationSettings();
        }

        public virtual void Configure()
        {
            routes.MapRoute(resourceName + "-Index", resourceName.ToLowerInvariant(), 
                new { controller = controllerName, action = settings.IndexActionName });

            if (settings.IncludeShowAction)
            {
                routes.MapRoute(resourceName + "-Show", resourceName.ToLowerInvariant() + "/{id}",
                    new { controller = controllerName, action = settings.ShowActionName },
                    new { id = settings.IdConstraint });
            }

            routes.MapRoute(resourceName + "-New", resourceName.ToLowerInvariant() + "/new",
                new { controller = controllerName, action = "New" });

            routes.MapRoute(resourceName + "-Edit", resourceName.ToLowerInvariant() + "/{id}/edit",
                new { controller = controllerName, action = "Edit" },
                new { id = settings.IdConstraint });

            if (settings.IncludeDeleteAction)
            {
                string path = resourceName.ToLowerInvariant() + "/{id}";
                if (settings.UseDistinctDeleteUrl)
                {
                    path += "/delete";
                }
                routes.MapRoute(resourceName + "-Delete", path,
                        new { controller = controllerName, action = "Delete" },
                        new { id = settings.IdConstraint, method = new HttpMethodConstraint(settings.DeleteHttpMethod) });
            }
            
        }
    }
}