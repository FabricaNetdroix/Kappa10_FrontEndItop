using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tier.Gui.Startup))]
namespace Tier.Gui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
