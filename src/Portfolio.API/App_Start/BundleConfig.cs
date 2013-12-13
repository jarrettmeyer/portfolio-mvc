using System.Web.Optimization;
using Portfolio.Lib;

namespace Portfolio.API.App_Start
{
    public class BundleConfig
    {
        public static void ConfigureBundles(BundleCollection bundles)
        {
            Ensure.ArgumentIsNotNull(bundles, "bundles");
            ConfigureCssBundles(bundles);
            ConfigureJsBundles(bundles);
        }

        private static void ConfigureCssBundles(BundleCollection bundles)
        {
            var cssBundle = new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.css");
            bundles.Add(cssBundle);
        }

        private static void ConfigureJsBundles(BundleCollection bundles)
        {
            var baseJsBundle = new ScriptBundle("~/Scripts/js")
                .Include("~/Scripts/jquery-2.0.3.js")                
                .Include("~/Scripts/modernizer-2.6.2.js")
                .Include("~/Scripts/underscore.js")
                .Include("~/Scripts/require.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/backbone.js");

            var appJsBundle = new ScriptBundle("~/Scripts/js/app")
                .Include("~/Scripts/app/views/MainWindowView.js") // Keep app/views/MainWindowView first, just for a bit of sanity.
                .Include("~/Scripts/app/models/CurrentUser.js")
                .Include("~/Scripts/app/views/LogonView.js");
                

            bundles.Add(baseJsBundle);
            bundles.Add(appJsBundle);
        }
    }
}
