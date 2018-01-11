using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Domain.Interfaces.Repositories
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        //////bool RoleExists(string nomeRole);
        //////IEnumerable<Role> GetByName(string nomeRole);

    }
}
