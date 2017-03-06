using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourOn.Startup))]
namespace TourOn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
