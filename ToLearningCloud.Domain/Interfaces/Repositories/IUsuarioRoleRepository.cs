using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Domain.Interfaces.Repositories
{
    public interface IUsuarioRoleRepository : IRepositoryBase<UsuarioRole>
    {
        //////void RemoveAllRoleUsersByRoleId(string idRole);
        //////IEnumerable<UsuarioRole> GetRoleUsersByRoleId(string idRole);
    }
}
