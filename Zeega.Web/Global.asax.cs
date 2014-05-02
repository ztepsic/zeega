using System.Globalization;
using System.Threading;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Zeega.Web {
    /// <summary>
    /// MVC application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication {

        /// <summary>
        /// Application start
        /// </summary>
        protected void Application_Start() {
            var appConfig = WebConfigurationManager.GetSection("appConfig") as AppConfig;

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(appConfig.Language);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.DefaultThreadCurrentUICulture;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Application begin request
        /// </summary>
        protected void Application_BeginRequest() { }

    }
}
