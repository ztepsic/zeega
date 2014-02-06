using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeega.Web.Startup))]
namespace Zeega.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
