using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CmsCore.Startup))]
namespace CmsCore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
