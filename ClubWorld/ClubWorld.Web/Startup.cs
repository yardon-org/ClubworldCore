using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClubWorld.Startup))]
namespace ClubWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
