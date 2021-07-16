using AutoMapper;

using Prime.Models;

namespace Prime.ViewModels.Profiles
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<Address, AddressViewModel>();
            CreateMap<AddressViewModel, PhysicalAddress>();
            CreateMap<AddressViewModel, MailingAddress>();
            CreateMap<AddressViewModel, VerifiedAddress>();

            CreateMap<Contact, ContactViewModel>()
                .ReverseMap();
        }
    }
}
