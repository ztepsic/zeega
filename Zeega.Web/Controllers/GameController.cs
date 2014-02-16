using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeega.Web.Controllers {
    /// <summary>
    /// Game controler
    /// </summary>
    public class GameController : Controller {
        //
        // GET: /Game/
        public ActionResult Index() {
            return View();
        }

        public String Category(string categorySlug) {
            return categorySlug;
        }

        /// <summary>
        /// Page with game information
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="gameSlug">Game slug</param>
        /// <returns>Web page</returns>
        public ActionResult Info(int gameId, string gameSlug) {
            return View();
        }

        /// <summary>
        /// Play game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="gameSlug">Game slug</param>
        /// <returns>Web page</returns>
        public ActionResult Play(int gameId, string gameSlug) {
            return View();
        }
    }
}