using System.Collections.Generic;
using System.Linq;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;

namespace ToLearningCloud.Infra.Data.Repositories
{
    public class AssinaturaNivelRepository : RepositoryBase<AssinaturaNivel>, IAssinaturaNivelRepository
    {
        public IEnumerable<AssinaturaNivel> GetByStatus(string status)
        {
            string[] arrayStatus = status.Split(',');

            return ContextDB.Set<AssinaturaNivel>().Where(a => arrayStatus.Contains(a.AssinaturaNivel_Status)).ToList();
        }
    }
}

