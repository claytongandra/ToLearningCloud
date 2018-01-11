using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Domain.Services
{
    public class AssinaturaNivelService : ServiceBase<AssinaturaNivel>, IAssinaturaNivelService
    {
        //////private readonly IAssinaturaNivelRepository _assinaturaNivelRepository;

        //////public AssinaturaNivelService(IAssinaturaNivelRepository assinaturaNivelRepository)
        //////    : base(assinaturaNivelRepository)
        //////{
        //////    _assinaturaNivelRepository = assinaturaNivelRepository;
        //////}

        //////public IEnumerable<AssinaturaNivel> GetByStatus(string status)
        //////{
        //////    return _assinaturaNivelRepository.GetByStatus(status);
        //////}
    }
}
