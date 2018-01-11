using System.Collections.Generic;
using System.Linq;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;

namespace ToLearningCloud.Infra.Data.Repositories
{
    public class UsuarioRoleRepository : RepositoryBase<UsuarioRole>, IUsuarioRoleRepository
    {

        //////public void RemoveAllRoleUsersByRoleId(string idRole)
        //////{
        //////    var allRoleUsers = ContextDB.Set<UsuarioRole>().Where(x => x.UsuarioRole_RoleCodigo == idRole).ToList();

        //////    if (allRoleUsers.Count() > 0)
        //////        ContextDB.Set<UsuarioRole>().RemoveRange(allRoleUsers);
        //////}

        //////public IEnumerable<UsuarioRole> GetRoleUsersByRoleId(string idRole)
        //////{
        //////    return ContextDB.Set<UsuarioRole>().Where(a => a.UsuarioRole_RoleCodigo == idRole).ToList();
        //////}

    }
}
