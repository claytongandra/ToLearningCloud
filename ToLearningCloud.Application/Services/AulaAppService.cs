using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Application.Services
{
    public class AulaAppService : AppServiceBase<Aula>, IAulaAppService
    {
        //////private readonly IAulaService _aulaService;

        //////public AulaAppService(IAulaService aulaService)
        //////    : base(aulaService)
        //////{
        //////    _aulaService = aulaService;
        //////}

        //////public IEnumerable<Aula> GetByStatusAula(string status)
        //////{
        //////    return _aulaService.GetByStatus(status);
        //////}

        //////public void CreateAula(Aula aula)
        //////{
        //////    BeginTransactionUoW();
        //////    _aulaService.Add(aula);
        //////    ComitUoW();
        //////}

        //////public void UpdateAula(Aula aula)
        //////{
        //////    BeginTransactionUoW();
        //////    _aulaService.Update(aula);
        //////    ComitUoW();
        //////}

        //////public void ChangeStatusAula(Aula aula, string status)
        //////{
        //////    aula.Aula_Status = status;
        //////    UpdateAula(aula);
        //////}

    }
}
