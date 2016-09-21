using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LTE.Web.Startup))]
namespace LTE.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
