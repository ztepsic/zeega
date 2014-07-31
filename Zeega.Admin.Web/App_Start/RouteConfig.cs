using System.Web.Mvc;
using System.Web.Routing;

namespace Zeega.Admin.Web {
    /// <summary>
    /// Route configuration
    /// </summary>
    public class RouteConfig {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GameProviderEdit",
                url: "game-provider/edit/{id}/{slug}",
                defaults: new { controller = "GameProvider", action = "Edit", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GameProvider",
                url: "game-provider/{id}/{slug}",
                defaults: new { controller = "GameProvider", action = "Details", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GameProviders",
                url: "game-providers/{action}",
                defaults: new { controller = "GameProvider", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
