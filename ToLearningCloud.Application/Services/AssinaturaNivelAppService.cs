using System.Collections.Generic;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Application.Services
{
    public class AssinaturaNivelAppService : AppServiceBase<AssinaturaNivel>, IAssinaturaNivelAppService
    {
        //////private readonly IAssinaturaNivelService _assinaturaNivelService;

        //////public AssinaturaNivelAppService(IAssinaturaNivelService assinaturaNivelService)
        //////    : base(assinaturaNivelService)
        //////{
        //////    _assinaturaNivelService = assinaturaNivelService;
        //////}

        //////public IEnumerable<AssinaturaNivel> GetByStatusAssinaturaNivel(string status)
        //////{
        //////    return _assinaturaNivelService.GetByStatus(status);
        //////}
    }
}
