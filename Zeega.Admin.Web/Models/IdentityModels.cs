using Microsoft.AspNet.Identity.EntityFramework;

namespace Zeega.Admin.Web.Models {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationUser : IdentityUser {
    }

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        /// <summary>
        /// 
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection") {
        }
    }
}