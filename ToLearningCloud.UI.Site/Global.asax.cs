using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ToLearningCloud.UI.Site.AutoMapper;

namespace ToLearningCloud.UI.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

        }
    }
}
