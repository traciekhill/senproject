using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(senproject.Startup))]
namespace senproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
