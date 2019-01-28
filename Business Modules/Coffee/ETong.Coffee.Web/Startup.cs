using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ETong.Coffee.Web.Startup))]
namespace ETong.Coffee.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
