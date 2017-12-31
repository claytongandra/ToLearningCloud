using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Application.Interfaces
{
    public interface IAssinaturaNivelAppService : IAppServiceBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatusAssinaturaNivel(string status);
    }
}
