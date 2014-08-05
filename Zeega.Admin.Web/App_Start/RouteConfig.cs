using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
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
                name: "GameProviderIndex",
                url: "game/providers",
                defaults: new { controller = "GameProvider", action = "Index" }
            );

            routes.MapRoute(
                name: "GameProviderEdit",
                url: "game/provider/edit/{id}/{slug}",
                defaults: new { controller = "GameProvider", action = "Edit", slug = UrlParameter.Optional },
                constraints: new { id = new IntRouteConstraint() }
            );

            routes.MapRoute(
                name: "GameProvider",
                url: "game/provider/create",
                defaults: new { controller = "GameProvider", action = "Create" }
            );

            routes.MapRoute(
                name: "GameProviderDetails",
                url: "game/provider/{id}/{slug}",
                defaults: new { controller = "GameProvider", action = "Details", slug = UrlParameter.Optional },
                constraints: new { id = new IntRouteConstraint() }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
