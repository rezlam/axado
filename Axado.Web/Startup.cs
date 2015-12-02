using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Axado.Web.Startup))]
namespace Axado.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
