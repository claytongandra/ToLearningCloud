using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Domain.Interfaces.Services
{
    public interface IRoleService : IServiceBase<Role>
    {
        //////bool RoleExists(string nomeRole);
        //////IEnumerable<Role> GetByName(string nomeRole);
    }
}
