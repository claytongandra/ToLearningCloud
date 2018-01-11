using AutoMapper;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.UI.Site.Areas.Admin.ViewModels;

namespace ToLearningCloud.UI.Site.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Aula, AulaViewModel>();
        }
    }

}