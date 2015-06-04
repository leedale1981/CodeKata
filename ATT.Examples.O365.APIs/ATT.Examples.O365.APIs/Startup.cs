using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATT.Examples.O365.APIs.Startup))]
namespace ATT.Examples.O365.APIs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
