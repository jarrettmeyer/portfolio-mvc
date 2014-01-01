using System.Diagnostics.Contracts;
using System.Web.Optimization;

namespace Portfolio.App_Start
{
    public static class BundleConfig
    {
        public static void ConfigureBundles(BundleCollection bundles)
        {
            Contract.Requires(bundles != null);            
            ConfigureCssBundles(bundles);
            ConfigureJsBundles(bundles);
        }

        private static void ConfigureCssBundles(BundleCollection bundles)
        {
            var cssBundle = new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/stylesheets/Site.css")
                .Include("~/Content/stylesheets/TaskList.css");
            bundles.Add(cssBundle);
        }

        private static void ConfigureJsBundles(BundleCollection bundles)
        {
            var jsBundle = new ScriptBundle("~/Scripts/js")
                .Include("~/Scripts/jquery-2.0.3.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/App/bindDeleteLinks.js")
                .Include("~/Scripts/App/SlugGenerator.js");
            bundles.Add(jsBundle);
        }
    }
}