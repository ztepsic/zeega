using System.Web.Optimization;

namespace Zeega.Admin.Web {
    /// <summary>
    /// Bundle configuration
    /// </summary>
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /// <summary>
        /// Register bundles
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/assets/js/jquery").Include(
                        "~/assets/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/assets/js/jqueryval")
                .Include("~/assets/js/jquery.validate.js")
                .Include("~/assets/js/jquery.validate.unobtrusive.js")
                .Include("~/assets/js/jquery.validate.bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/assets/js/modernizr").Include(
                        "~/assets/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/assets/js/bootstrap").Include(
                      "~/assets/js/bootstrap.js"
                //          "~/assets/js/respond.js" // it is  already defined through CDN network
            ));

            bundles.Add(new StyleBundle("~/assets/css/style").Include(
                      "~/assets/css/bootstrap.css",
                      "~/assets/css/style.css"));
        }
    }
}
