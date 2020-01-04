using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CycleHome.Startup))]
namespace CycleHome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
