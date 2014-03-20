using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SO.SilList.Web.Startup))]
namespace SO.SilList.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
