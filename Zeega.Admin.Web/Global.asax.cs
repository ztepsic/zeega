using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Zeega.Admin.Web {
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
