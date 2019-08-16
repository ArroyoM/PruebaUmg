using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaUmg.Startup))]
namespace PruebaUmg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
