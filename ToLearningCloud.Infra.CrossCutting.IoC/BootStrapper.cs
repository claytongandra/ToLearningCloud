////using Microsoft.Practices.ServiceLocation;
////using CommonServiceLocator.SimpleInjectorAdapter;
////using SimpleInjector;
////using ToLearningCloud.Domain.Interfaces.Repositories;
////using ToLearningCloud.Domain.Interfaces.Services;
////using ToLearningCloud.Domain.Services;
////using ToLearningCloud.Application.Interfaces;
////using ToLearningCloud.Application.Services;
////using ToLearningCloud.Infra.Data.Repositories;
////using ToLearningCloud.Infra.CrossCutting.Identity.Context;
////using ToLearningCloud.Infra.CrossCutting.Identity.Configuration;
////using ToLearningCloud.Infra.CrossCutting.Identity.Model;
////using Microsoft.AspNet.Identity;
////using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Application.Services;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;
using ToLearningCloud.Domain.Services;
using ToLearningCloud.Infra.CrossCutting.Identity.Configuration;
using ToLearningCloud.Infra.CrossCutting.Identity.Context;
using ToLearningCloud.Infra.CrossCutting.Identity.Model;
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

            //////            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            //////            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            //////            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);

            //////            //container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            //////            //container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);


            //////            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            //////            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            //////            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);


            //////container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);

            container.Register<IUsuarioAcessoRepository, UsuarioAcessoRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioAcessoAppService, UsuarioAcessoAppService>();
            container.Register<IUsuarioAcessoService, UsuarioAcessoService>();

            //////            //container.Register<IRoleRepository, RoleRepository>(Lifestyle.Scoped);
            //////            //container.Register<IRoleAppService, RoleAppService>(Lifestyle.Scoped);
            //////            //container.Register<IRoleService, RoleService>(Lifestyle.Scoped);

            //////            //container.Register<IUsuarioRoleRepository, UsuarioRoleRepository>(Lifestyle.Scoped);
            //////            //container.Register<IUsuarioRoleAppService, UsuarioRoleAppService>(Lifestyle.Scoped);
            //////            //container.Register<IUsuarioRoleService, UsuarioRoleService>(Lifestyle.Scoped);

            //////            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            //////            ServiceLocator.SetLocatorProvider(() => adapter);

            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
        }
    }
}
