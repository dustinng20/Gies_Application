using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gies_Application.Startup))]
namespace Gies_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
