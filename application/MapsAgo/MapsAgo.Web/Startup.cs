using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapsAgo.Web.Startup))]
namespace MapsAgo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
