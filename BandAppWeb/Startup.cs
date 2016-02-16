using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BandAppWeb.Startup))]
namespace BandAppWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
