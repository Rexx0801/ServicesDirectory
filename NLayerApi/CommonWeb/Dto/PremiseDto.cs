namespace Common.Dto;

public class PremiseDto
{
    public Guid PremiseId { get; set; }
    public string PremiseName { get; set; } = null!;
    public string LocationName { get; set; } = null!;
    public string? KnownAs { get; set; }
    public string LocationStatus { get; set; } = null!;
    public DateOnly? LocationStatusDate { get; set; }
    public bool? PrimaryLocation { get; set; }
    public bool? LocationManaged { get; set; }
    public bool? StnetworkConnectivity { get; set; }
    public string? LocationDescription { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string? GeneralFaxNumber { get; set; }
    public string? MiniCommNumber { get; set; }
    public bool? IsNewShop { get; set; }
    public DateOnly? ShopFlagDate { get; set; }
    public bool SpecialistShop { get; set; }
    public bool? IsActive { get; set; }
    public string? MediaContactName { get; set; }
    public string? LocalDemographicNotes { get; set; }
    public string? CateringContact { get; set; }
    public string? CateringType { get; set; }
    public string? Network { get; set; }
    public string? ClientItfacilitiesDetails { get; set; }
    public bool? RoomAvailability { get; set; }
    public string? TravelDetails { get; set; }
    public string? TravelNearestBus { get; set; }
    public string? TravelNearestRail { get; set; }
    public string? TravelNearestAirport { get; set; }
    public string? HostingContact { get; set; }
    public int? VisitorParkingSpaces { get; set; }
    public string? VisitorParkingAlternative { get; set; }
    public Guid AddressId { get; set; }
    public Guid ServiceId { get; set; }
    public Guid? ContactId { get; set; }

    public AddressDto Address { get; set; } = null!;
    public ContactDto? Contact { get; set; }
    public ICollection<AccreditationDto> Accreditations { get; set; } = new List<AccreditationDto>();
    public ICollection<FacilityDto> Facilities { get; set; } = new List<FacilityDto>();
    public ICollection<JcpofficeDto> Jcpoffices { get; set; } = new List<JcpofficeDto>();
    public ICollection<LocalDemographicIssueDto> LocalDemographicIssues { get; set; } = new List<LocalDemographicIssueDto>();
    public ICollection<LocalHotelDto> LocalHotels { get; set; } = new List<LocalHotelDto>();
    public ICollection<LocationOpenDayDto> LocationOpenDays { get; set; } = new List<LocationOpenDayDto>();
    public ICollection<LocationTypeDto> LocationTypes { get; set; } = new List<LocationTypeDto>();
    public ICollection<MinorWorkDto> MinorWorks { get; set; } = new List<MinorWorkDto>();
    public ICollection<OutreachLocationDto> OutreachLocations { get; set; } = new List<OutreachLocationDto>();
    public ICollection<PremiseRateDto> PrimiseRates { get; set; } = new List<PremiseRateDto>();
    public ICollection<VolunteeringDto> Volunteerings { get; set; } = new List<VolunteeringDto>();
}
