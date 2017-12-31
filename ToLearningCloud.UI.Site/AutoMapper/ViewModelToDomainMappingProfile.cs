using AutoMapper;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.UI.Site.Areas.Admin.ViewModels;

namespace ToLearningCloud.UI.Site.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AulaViewModel, Aula>();
        }
    }

}