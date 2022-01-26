using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalRuiz2018.Startup))]
namespace FinalRuiz2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
