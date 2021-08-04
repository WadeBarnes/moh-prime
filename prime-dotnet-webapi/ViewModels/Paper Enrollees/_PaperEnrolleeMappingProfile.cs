using AutoMapper;

using Prime.Models;
using Prime.ViewModels.PaperEnrollees;

namespace Prime.ViewModels.Profiles
{
    public class PaperEnrolleesMappingProfile : Profile
    {
        public PaperEnrolleesMappingProfile()
        {
            CreateMap<PaperEnrolleeDemographicViewModel, Enrollee>();
            CreateMap<PaperEnrolleeCertificationViewModel, Certification>();
            CreateMap<PaperEnrolleeSelfDeclarationViewModel, SelfDeclaration>();
            CreateMap<PaperEnrolleeOboSiteViewModel, OboSite>();
        }
    }
}
