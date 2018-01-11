using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Domain.Services
{
    public class AulaService : ServiceBase<Aula>, IAulaService
    {
        //////private readonly IAulaRepository _aulaRepository;

        //////public AulaService(IAulaRepository aulaRepository)
        //////    : base(aulaRepository)
        //////{
        //////    _aulaRepository = aulaRepository;
        //////}

        //////public IEnumerable<Aula> GetByStatus(string status)
        //////{
        //////    return _aulaRepository.GetByStatus(status);
        //////}
    }
}
