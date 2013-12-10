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
                .Include("~/Content/bootstrap")
                .Include("~/Content/Site");
            bundles.Add(cssBundle);
        }

        private static void ConfigureJsBundles(BundleCollection bundles)
        {
            var jsBundle = new ScriptBundle("~/Scripts/js")
                .Include("~/Scripts/jquery-*")                
                .Include("~/Scripts/modernizer-*")
                .Include("~/Scripts/require")
                .Include("~/Scripts/bootstrap.js");
            bundles.Add(jsBundle);
        }
    }
}
