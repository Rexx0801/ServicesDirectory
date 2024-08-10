using AutoMapper;
using Common.Dto;
using DataAccess.Entities;

namespace BusinessLayer.AutoMapperProfile;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<Premise, PremiseDto>()
            .ForMember(dest => dest.LocationTypes, opt => opt.MapFrom(src => src.LocationTypes));
        CreateMap<Address, AddressDto>();
        CreateMap<Contact, ContactDto>();
        CreateMap<Accreditation, AccreditationDto>();
        CreateMap<JcpOffice, JcpofficeDto>();
        CreateMap<LocalDemographicIssue, LocalDemographicIssueDto>();
        CreateMap<LocalHotel, LocalHotelDto>();
        CreateMap<LocationOpenDay, LocationOpenDayDto>();
        CreateMap<LocationType, LocationTypeDto>();
        CreateMap<FacilityDto, Facility>().ReverseMap();
        CreateMap<MinorWork, MinorWorkDto>().ReverseMap();
        CreateMap<Volunteering, VolunteeringDto>().ReverseMap();

        CreateMap<OutreachLocation, OutreachLocationDto>();
        CreateMap<PremiseRate, PremiseRateDto>();
    }
}