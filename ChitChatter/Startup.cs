using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChitChatter.Startup))]
namespace ChitChatter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
