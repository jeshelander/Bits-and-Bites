using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bits_and_Bites.Startup))]
namespace Bits_and_Bites
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
