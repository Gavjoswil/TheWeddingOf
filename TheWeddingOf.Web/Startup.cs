using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheWeddingOf.Web.Startup))]
namespace TheWeddingOf.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
