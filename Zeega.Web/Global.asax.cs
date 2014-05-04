using System;
using System.Globalization;
using System.Threading;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Zeega.Web.App_Start;

namespace Zeega.Web {
    /// <summary>
    /// MVC application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication {

        #region Fields and Properties

        /// <summary>
        /// Gets application config
        /// </summary>
        public static IAppConfig AppConfig { get { return WebConfigurationManager.GetSection("appConfig") as IAppConfig; } }

        #endregion

        /// <summary>
        /// Application start
        /// </summary>
        protected void Application_Start() {
            // Set culture info
            //CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(AppConfig.Language);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture(AppConfig.Language);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(AppConfig.Language);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Configure();
        }

        /// <summary>
        /// Application begin request
        /// </summary>
        protected void Application_BeginRequest() { }

    }
}
