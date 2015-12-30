using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TryItTop10ContentWords.Startup))]
namespace TryItTop10ContentWords
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
