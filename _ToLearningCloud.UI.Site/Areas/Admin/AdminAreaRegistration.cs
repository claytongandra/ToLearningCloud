using System.Web.Mvc;

namespace ToLearningCloud.UI.Site.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Panel", action = "Index", id = UrlParameter.Optional },
                new[] { "ToLearningCloud.UI.Site.Areas.Admin.Controllers" }
            );
        }
    }
}