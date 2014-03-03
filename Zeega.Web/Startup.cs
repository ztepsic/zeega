using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeega.Web.Startup))]
namespace Zeega.Web {
    /// <summary>
    /// Startup partial class
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
