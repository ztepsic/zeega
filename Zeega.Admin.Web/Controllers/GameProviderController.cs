using System.Web.Mvc;
using Zeega.Admin.Web.Models.Game;

namespace Zeega.Admin.Web.Controllers {
    /// <summary>
    /// Game provider controller
    /// </summary>
    public class GameProviderController : Controller {
        
        /// <summary>
        /// Displays all game providers
        /// </summary>
        /// <returns></returns>
        public ViewResult Index() {
            return View();
        }

        /// <summary>
        /// Displays form page for creating game provider
        /// </summary>
        /// <returns>Page for creating game provider</returns>
        public ViewResult Create() {
            return View(new GameProviderModel());
        }

        /// <summary>
        /// Creates a new game provider based on form data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(GameProviderModel gameProviderModel) {
            if (ModelState.IsValid) {
                TempData["message"] = string.Format("{0} has been created.", gameProviderModel.Name);
                return RedirectToAction("Index");
            } else {
                return View(gameProviderModel);
            }
        }
    }
}