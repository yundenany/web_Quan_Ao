using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Ban_Quan_Ao.Startup))]
namespace Web_Ban_Quan_Ao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
