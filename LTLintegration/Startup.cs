using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LTLintegration.Startup))]
namespace LTLintegration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
