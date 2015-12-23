using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayslipGenerator.Startup))]
namespace PayslipGenerator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
