using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contas_a_Pagar___Web.Startup))]
namespace Contas_a_Pagar___Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
