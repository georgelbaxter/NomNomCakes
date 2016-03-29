using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NomNomCakes.Startup))]
namespace NomNomCakes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
