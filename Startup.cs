using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pop.ly.Startup))]
namespace Pop.ly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
