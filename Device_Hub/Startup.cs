using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Device_Hub.Startup))]
namespace Device_Hub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
