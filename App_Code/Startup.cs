using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FWP.Startup))]
namespace FWP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
