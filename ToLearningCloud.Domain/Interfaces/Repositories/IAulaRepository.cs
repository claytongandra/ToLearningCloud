using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Domain.Interfaces.Repositories
{
    public interface IAulaRepository : IRepositoryBase<Aula>
    {
        IEnumerable<Aula> GetByStatus(string status);
    }

}
