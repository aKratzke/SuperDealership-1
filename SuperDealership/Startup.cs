using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperDealership.Startup))]
namespace SuperDealership
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
