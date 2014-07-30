using Microsoft.Owin;
using Owin;
using Zeega.Admin.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace Zeega.Admin.Web {
    /// <summary>
    /// Startup
    /// </summary>
    public partial class Startup {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
