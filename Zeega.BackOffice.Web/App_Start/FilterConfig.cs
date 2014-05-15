using System.Web;
using System.Web.Mvc;

namespace Zeega.BackOffice.Web {
    /// <summary>
    /// Filter config
    /// </summary>
    public class FilterConfig {
        /// <summary>
        /// Register gloval fitlers
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
