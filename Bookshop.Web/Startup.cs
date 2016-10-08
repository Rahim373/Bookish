using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookshop.Web.Startup))]
namespace Bookshop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
