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
                routes.MapRoute(resourceName + "-Show", resourceName.ToLowerInvariant() + "/{" + settings.ShowActionParameter + "}",
                    new { controller = controllerName, action = settings.ShowActionName });
            }
        }
    }
}