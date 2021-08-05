using System.Linq;
using AutoMapper;

using Prime.Models;
using Prime.DTOs.AgreementEngine;
using Prime.ViewModels.Emails;
using Prime.ViewModels.Parties;

/**
 * Automapper Documentation
 * @see https://docs.automapper.org/en/stable
 */
namespace Prime.ViewModels.Profiles
{
    public class OriginalMappingProfile : Profile
    {
        public OriginalMappingProfile()
        {
            int? careSettingCode = null;
            CreateMap<Organization, OrganizationListViewModel>()
                .ForMember(dest => dest.HasAcceptedAgreement, opt => opt.MapFrom(src => src.Agreements.Any(a => a.AcceptedDate.HasValue)))
                .ForMember(dest => dest.HasSubmittedSite, opt => opt.MapFrom(src => src.Sites.Any(s => s.SubmittedDate.HasValue)))
                .ForMember(dest => dest.Sites, opt => opt.MapFrom(src => src.Sites.Where(s => careSettingCode == null || s.CareSettingCode == careSettingCode)));
            CreateMap<CommunitySite, SiteListViewModel>()
                .ForMember(dest => dest.AdjudicatorIdir, opt => opt.MapFrom(src => src.Adjudicator.IDIR))
                .ForMember(dest => dest.RemoteUserCount, opt => opt.MapFrom(src => src.RemoteUsers.Count));
            CreateMap<BusinessLicence, BusinessLicence>();
            CreateMap<EnrolleeCreateModel, Enrollee>();

            IQueryable<int> newestAgreementIds = null;
            CreateMap<Enrollee, EnrolleeListViewModel>()
                .ForMember(dest => dest.CurrentStatusCode, opt => opt.MapFrom(src => src.CurrentStatus.StatusCode))
                .ForMember(dest => dest.AdjudicatorIdir, opt => opt.MapFrom(src => src.Adjudicator.IDIR))
                .ForMember(dest => dest.HasNewestAgreement, opt => opt.MapFrom(src => newestAgreementIds.Any(n => n == src.CurrentAgreementId)))
                .ForMember(dest => dest.RemoteAccess, opt => opt.MapFrom(src => src.EnrolleeRemoteUsers.Any()))
                .ForMember(dest => dest.CareSettingCodes, opt => opt.MapFrom(src => src.EnrolleeCareSettings.Select(ecs => ecs.CareSettingCode)))
                .ForMember(dest => dest.RequiresConfirmation, opt => opt.MapFrom(src =>
                    !src.Submissions.OrderByDescending(s => s.CreatedDate).FirstOrDefault().Confirmed
                    && src.PreviousStatus.StatusCode == (int)StatusType.RequiresToa
                ))
                .ForMember(dest => dest.Confirmed, opt => opt.MapFrom(src => src.Submissions.OrderByDescending(s => s.CreatedDate).FirstOrDefault().Confirmed));

            CreateMap<Enrollee, EnrolleeViewModel>()
            .ForMember(dest => dest.CurrentStatusCode, opt => opt.MapFrom(src => src.CurrentStatus.StatusCode))
            .ForMember(dest => dest.AdjudicatorIdir, opt => opt.MapFrom(src => src.Adjudicator.IDIR))
            .ForMember(dest => dest.RequiresConfirmation, opt => opt.MapFrom(src =>
                !src.Submissions.OrderByDescending(s => s.CreatedDate).FirstOrDefault().Confirmed
                && src.PreviousStatus.StatusCode == (int)StatusType.RequiresToa
            ))
            .ForMember(dest => dest.Confirmed, opt => opt.MapFrom(src => src.Submissions.OrderByDescending(s => s.CreatedDate).FirstOrDefault().Confirmed))
            .AfterMap((src, dest) => dest.IsRegulatedUser = src.IsRegulatedUser());

            CreateMap<Agreement, AgreementViewModel>()
                .ForMember(dest => dest.SignedAgreementDocumentGuid, opt =>
                {
                    opt.PreCondition(src => src.SignedAgreement != null);
                    opt.MapFrom(src => src.SignedAgreement.DocumentGuid);
                })
                .ForMember(dest => dest.AgreementType, opt => opt.MapFrom(src => src.AgreementVersion.AgreementType));

            CreateMap<EnrolleeNote, EnrolleeNoteViewModel>();
            CreateMap<SiteRegistrationNote, SiteRegistrationNoteViewModel>();

            // DTOs
            CreateMap<Enrollee, AgreementEngineDto>()
                .ForMember(dest => dest.CareSettingCodes, opt => opt.MapFrom(src => src.EnrolleeCareSettings.Select(ecs => ecs.CareSettingCode)));
            CreateMap<Certification, CertificationDto>();

            CreateMap<Banner, BannerDisplayViewModel>();
            CreateMap<Banner, BannerViewModel>();

            CreateMap<EmailTemplate, EmailTemplateViewModel>();
            CreateMap<EmailTemplate, EmailTemplateListViewModel>();

            CreateMap<GisEnrolment, GisViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Party.UserId))
                .ForMember(dest => dest.HPDID, opt => opt.MapFrom(src => src.Party.HPDID))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Party.FirstName))
                .ForMember(dest => dest.GivenNames, opt => opt.MapFrom(src => src.Party.GivenNames))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Party.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Party.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Party.Phone));

            CreateMap<AgreementVersion, AgreementVersionViewModel>();
            CreateMap<AgreementVersion, AgreementVersionListViewModel>();

            // Don't copy over primary keys
            CreateMap<PlrProvider, PlrProvider>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ipc, opt => opt.Ignore());
        }
    }
}
