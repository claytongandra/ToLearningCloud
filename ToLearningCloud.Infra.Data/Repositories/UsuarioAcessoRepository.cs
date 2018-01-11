using Microsoft.Practices.ServiceLocation;
using System.Data.Entity;
using System.Linq;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Infra.Data.Context;
using ToLearningCloud.Infra.Data.EntityFramework;

namespace ToLearningCloud.Infra.Data.Repositories
{
    public class UsuarioAcessoRepository : IUsuarioAcessoRepository
    {
        //////    protected DbContext IdentityContextDB { get; private set; }

        //////    public UsuarioAcessoRepository()
        //////    {
        //////        var contextManager = ServiceLocator.Current.GetInstance<ContextManager<UsuarioToLearningCloudContext>>();
        //////        IdentityContextDB = contextManager.GetContext;
        //////    }


        //////    public UsuarioAcesso GetAcessoByUsuarioId(string id)
        //////    {
        //////        return IdentityContextDB.Set<UsuarioAcesso>().Find(id);
        //////    }

        //////    public string GetLoginByEmailOrUser(string login)
        //////    {
        //////        UsuarioAcesso retornoQueryUser = (from UserLogin in IdentityContextDB.Set<UsuarioAcesso>()
        //////                                          where (UserLogin.UsuarioAcesso_Email == login || UserLogin.UsuarioAcesso_UserName == login)
        //////                                          select UserLogin).SingleOrDefault();

        //////        if (retornoQueryUser == null)
        //////        {
        //////            return null;
        //////        }

        //////        return retornoQueryUser.UsuarioAcesso_UserName;
        //////    }

            public void Dispose()
           {
        //////        IdentityContextDB.Dispose();
            }
    }
}
