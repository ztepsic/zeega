using System.Web.Mvc;
using System.Web.Routing;
using Zeega.Web.Localization;

namespace Zeega.Web {
    /// <summary>
    /// Route configuration
    /// </summary>
    public class RouteConfig {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routes">Routes that needs to be registered</param>
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Game.Info",
                url: Resource.Game + "/{gameId}/{gameSlug}",
                defaults: new { controller = "Game", action = "Info" }
            );

            routes.MapRoute(
                name: "Game.Play",
                url: Resource.Play + "/{gameId}/{gameSlug}",
                defaults: new { controller = "Game", action = "Play" }
            );

            routes.MapRoute(
               name: "Game.Category",
               url: "{categorySlug}-" + Resource.Games,
               defaults: new { controller = "Game", action = "Category" }
           );

            routes.MapRoute(
                name: "Game.Games",
                url: Resource.Games,
                defaults: new { controller = "Game", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
