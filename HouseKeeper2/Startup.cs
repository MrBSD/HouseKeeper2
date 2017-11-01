using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseKeeper2.Startup))]
namespace HouseKeeper2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
