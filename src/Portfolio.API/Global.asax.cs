using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using Portfolio.API.App_Start;

namespace Portfolio.API
{
    public class PortfolioApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.ConfigureBundles(BundleTable.Bundles);
        }
    }
}
