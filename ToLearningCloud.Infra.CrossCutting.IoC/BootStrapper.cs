using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.SimpleInjectorAdapter;
using SimpleInjector;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;
using ToLearningCloud.Domain.Services;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Application.Services;
using ToLearningCloud.Infra.Data.Repositories;

namespace ToLearningCloud.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
           
            container.Register<IUnitOfWorkRepository, UnitOfWorkRepository>();

            container.Register<IAulaAppService, AulaAppService>(Lifestyle.Scoped);
            container.Register<IAulaService, AulaService>(Lifestyle.Scoped);
            container.Register<IAulaRepository, AulaRepository>(Lifestyle.Scoped);

            container.Register<IAssinaturaNivelAppService, AssinaturaNivelAppService>(Lifestyle.Scoped);
            container.Register<IAssinaturaNivelService, AssinaturaNivelService>(Lifestyle.Scoped);
            container.Register<IAssinaturaNivelRepository, AssinaturaNivelRepository>(Lifestyle.Scoped);


            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);
        }
    }
}
