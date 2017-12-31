using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Domain.Interfaces.Services
{
    public interface IAssinaturaNivelService : IServiceBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatus(string status);
    }
}
