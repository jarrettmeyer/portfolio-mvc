using System;
using System.Diagnostics.Contracts;
using System.Web.Optimization;

namespace Portfolio.API.App_Start
{
    public class BundleConfig
    {
        public static void ConfigureBundles(BundleCollection bundles)
        {
            Contract.Requires<ArgumentNullException>(bundles != null);
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
            var baseJsBundle = new ScriptBundle("~/Scripts/js")
                .Include("~/Scripts/jquery-2.0.3.js")                
                .Include("~/Scripts/modernizer-2.6.2.js")
                .Include("~/Scripts/bootstrap.js");
            bundles.Add(baseJsBundle);            
        }
    }
}
