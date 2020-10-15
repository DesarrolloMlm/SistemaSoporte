using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Soporte.Startup))]
namespace Soporte
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
