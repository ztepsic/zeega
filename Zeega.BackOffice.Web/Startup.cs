using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeega.BackOffice.Web.Startup))]
namespace Zeega.BackOffice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
