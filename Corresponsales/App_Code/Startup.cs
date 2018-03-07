using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Corresponsales.Startup))]
namespace Corresponsales
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
