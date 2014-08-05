using System.Web.Mvc;
using Zed.Web.Models;
using Zeega.Admin.Web.Models;

namespace Zeega.Admin.Web.Controllers {
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            return View(new PageViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}