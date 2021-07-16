using AutoMapper;

using Prime.Models.HealthAuthorities;
using Prime.ViewModels.HealthAuthoritySites;

namespace Prime.ViewModels.Profiles
{
    public class HealthAuthoritySiteMappingProfile : Profile
    {
        public HealthAuthoritySiteMappingProfile()
        {
            CreateMap<HealthAuthoritySite, HealthAuthoritySiteViewModel>();
            CreateMap<HealthAuthoritySiteInfoViewModel, HealthAuthoritySite>();
            CreateMap<HealthAuthorityPharmanetAdministrator, HealthAuthoritySite>();
        }
    }
}
