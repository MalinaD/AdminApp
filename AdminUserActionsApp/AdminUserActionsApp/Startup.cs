using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminUserActionsApp.Startup))]
namespace AdminUserActionsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
