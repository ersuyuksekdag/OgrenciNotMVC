using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OgrenciNotMvc.Startup))]
namespace OgrenciNotMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
