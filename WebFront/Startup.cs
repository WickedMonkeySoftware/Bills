using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFront.Startup))]
namespace WebFront
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
