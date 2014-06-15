using System.Web;
using System.Web.Mvc;

namespace Zeega.Web {
    /// <summary>
    /// Filter configuration
    /// </summary>
    public class FilterConfig {
        /// <summary>
        /// Registers global filters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
