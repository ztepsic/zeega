using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Zeega.BackOffice.Web.App_Start;

namespace Zeega.BackOffice.Web {
    /// <summary>
    /// MVC application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication {
        /// <summary>
        /// Application strart
        /// </summary>
        protected void Application_Start() {
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
