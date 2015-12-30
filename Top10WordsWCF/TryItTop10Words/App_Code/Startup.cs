using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TryItTop10Words.Startup))]
namespace TryItTop10Words
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
