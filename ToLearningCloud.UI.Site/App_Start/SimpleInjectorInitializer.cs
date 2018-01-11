using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using SimpleInjector;
//using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebActivatorEx;
using ToLearningCloud.Infra.CrossCutting.IoC;
using ToLearningCloud.UI.Site.App_Start;
using ToLearningCloud.UI.Site.Controllers;
using SimpleInjector.Lifestyles;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace ToLearningCloud.UI.Site.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying)
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            }, Lifestyle.Scoped);

            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
                var registeredControllerTypes =
    SimpleInjectorMvcExtensions.GetControllerTypesToRegister(
        container, Assembly.GetExecutingAssembly());

            foreach (var controllerType in registeredControllerTypes)
            {
                container.Register(controllerType, controllerType, Lifestyle.Scoped);
            }

            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}