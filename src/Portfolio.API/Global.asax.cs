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
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);            
            BundleConfig.ConfigureBundles(BundleTable.Bundles);
        }
    }
}
