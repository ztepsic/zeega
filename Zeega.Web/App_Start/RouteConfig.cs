using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zeega.Web {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Game.Play",
                url: "game/{gameId}/{gameSlug}",
                defaults: new { controller = "Game", action = "Play" }
            );

            routes.MapRoute(
               name: "Game.Category",
               url: "{categorySlug}-games",
               defaults: new { controller = "Game", action = "Category" }
           );

            routes.MapRoute(
                name: "Game.Games",
                url: "games",
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
