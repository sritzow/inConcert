using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inConcert.Startup))]
namespace inConcert
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
