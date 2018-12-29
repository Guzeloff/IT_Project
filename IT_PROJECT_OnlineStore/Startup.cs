using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT_PROJECT_OnlineStore.Startup))]
namespace IT_PROJECT_OnlineStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
