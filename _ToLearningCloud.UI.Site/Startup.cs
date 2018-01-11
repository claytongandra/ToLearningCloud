using Microsoft.Owin;
using Owin;
using ToLearningCloud.UI.Site;

[assembly: OwinStartup(typeof(Startup))]

namespace ToLearningCloud.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
