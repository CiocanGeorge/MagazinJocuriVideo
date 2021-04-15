using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagazinJocuriVideo.Startup))]
namespace MagazinJocuriVideo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
