using System;
using System.Diagnostics.Contracts;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Portfolio.API.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Contract.Requires<ArgumentNullException>(config != null);            
            ConfigureJsonSettings(config);
            RegisterApiRoutes(config);
        }        

        private static void ConfigureJsonSettings(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static void RegisterApiRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
