using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Infra.Data.Context;
using ToLearningCloud.Infra.Data.EntityFramework;

namespace ToLearningCloud.Infra.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        //////protected DbContext IdentityContextDB { get; private set; }

        //////public RoleRepository()
        //////{
        //////    var contextManager = ServiceLocator.Current.GetInstance<ContextManager<ClaimsRolesNewLearningCloudContext>>();
        //////    IdentityContextDB = contextManager.GetContext;
        //////}
        //////public bool RoleExists(string nomeRole)
        //////{
        //////    var role = ContextDB.Set<Role>().Where(a => nomeRole == a.Role_Nome).FirstOrDefault();

        //////    if (role != null)
        //////        return true;

        //////    return false;
        //////}
        //////public IEnumerable<Role> GetByName(string nomeRole)
        //////{
        //////    return ContextDB.Set<Role>().Where(a => nomeRole.Contains(a.Role_Nome)).ToList();
        //////}

    }
}
