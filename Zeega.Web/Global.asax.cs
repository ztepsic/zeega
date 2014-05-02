using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Zed.NHibernate;

namespace Zeega.Web {
    /// <summary>
    /// MVC application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication {

        /// <summary>
        /// Application start
        /// </summary>
        protected void Application_Start() {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("hr-HR");
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
        protected void Application_BeginRequest() {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hr-HR");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("hr-HR");
        }

    }
}
