using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeega.BackOffice.Web.Startup))]
namespace Zeega.BackOffice.Web
{
    /// <summary>
    /// Startup
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
