using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapsAgo.WebUI.Startup))]
namespace MapsAgo.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
