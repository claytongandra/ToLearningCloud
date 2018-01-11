using System.Collections.Generic;
using System.Linq;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;

namespace ToLearningCloud.Infra.Data.Repositories
{
    public class AulaRepository : RepositoryBase<Aula>, IAulaRepository
    {
        //////public IEnumerable<Aula> GetByStatus(string status)
        //////{
        //////    string[] arrayStatus = status.Split(',');

        //////    return ContextDB.Set<Aula>().Where(a => arrayStatus.Contains(a.Aula_Status)).ToList();

        //////}
    }

}
