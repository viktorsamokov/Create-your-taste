using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CYT.Web.Startup))]
namespace CYT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
