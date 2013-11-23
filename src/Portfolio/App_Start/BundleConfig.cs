using System.Web.Optimization;
using Portfolio.Lib;

namespace Portfolio.App_Start
{
    public static class BundleConfig
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
                .Include("~/Content/bootstrap/bootstrap.css")
                .Include("~/Content/stylesheets/Site.css");
            bundles.Add(cssBundle);
        }

        private static void ConfigureJsBundles(BundleCollection bundles)
        {
            var jsBundle = new ScriptBundle("~/Scripts/js")
                .Include("~/Scripts/jquery-2.0.3.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/App/bindDeleteLinks.js")
                .Include("~/Scripts/App/SlugGenerator.js");
            bundles.Add(jsBundle);
        }
    }
}