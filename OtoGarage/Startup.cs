using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OtoGarage.Startup))]
namespace OtoGarage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
