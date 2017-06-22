using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DRCTS.Startup))]
namespace DRCTS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
