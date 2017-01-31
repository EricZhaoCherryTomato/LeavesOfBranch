using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommerceWeb.Startup))]
namespace CommerceWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
