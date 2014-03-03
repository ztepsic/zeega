using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeega.Web.Controllers {
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            return View();
        }
    }
}