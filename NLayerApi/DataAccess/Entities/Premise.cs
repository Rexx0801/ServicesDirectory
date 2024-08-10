using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Premise")]
public class Premise
{
    [Key]
    public Guid PremiseId { get; set; }

    [StringLength(255)]
    public string PremiseName { get; set; } = null!;

    [StringLength(255)]
    public string LocationName { get; set; } = null!;

    [StringLength(255)]
    public string? KnownAs { get; set; }

    [StringLength(100)]
    public string LocationStatus { get; set; } = null!;

    public DateOnly? LocationStatusDate { get; set; }

    public bool? PrimaryLocation { get; set; }

    public bool? LocationManaged { get; set; }

    public bool? STNetworkConnectivity { get; set; }

    [StringLength(255)]
    public string? LocationDescription { get; set; }

    [StringLength(15)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(100)]
    public string? GeneralFaxNumber { get; set; }

    [StringLength(100)]
    public string? MiniCommNumber { get; set; }

    public bool? IsNewShop { get; set; }

    public DateOnly? ShopFlagDate { get; set; }

    public bool SpecialistShop { get; set; }

    public bool? IsActive { get; set; }

    [StringLength(255)]
    public string? MediaContactName { get; set; }

    [StringLength(255)]
    public string? LocalDemographicNotes { get; set; }

    [StringLength(255)]
    public string? CateringContact { get; set; }

    [StringLength(255)]
    public string? CateringType { get; set; }

    [StringLength(255)]
    public string? Network { get; set; }

    [StringLength(255)]
    public string? ClientITFacilitiesDetails { get; set; }

    public bool? RoomAvailability { get; set; }

    [StringLength(255)]
    public string? TravelDetails { get; set; }

    [StringLength(255)]
    public string? TravelNearestBus { get; set; }

    [StringLength(255)]
    public string? TravelNearestRail { get; set; }

    [StringLength(255)]
    public string? TravelNearestAirport { get; set; }

    [StringLength(255)]
    public string? HostingContact { get; set; }

    public int? VisitorParkingSpaces { get; set; }

    [StringLength(255)]
    public string? VisitorParkingAlternative { get; set; }

    public Guid AddressId { get; set; }

    public Guid ServiceId { get; set; }

    public Guid? ContactId { get; set; }

    [InverseProperty("Premise")]
    public virtual ICollection<Accreditation> Accreditations { get; set; } = new List<Accreditation>();

    [ForeignKey("AddressId")]
    [InverseProperty("Premises")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("ContactId")]
    [InverseProperty("Premises")]
    public virtual Contact? Contact { get; set; }

    [InverseProperty("Premise")]
    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();

    [InverseProperty("Premise")]
    public virtual ICollection<JcpOffice> JCPOffices { get; set; } = new List<JcpOffice>();

    [InverseProperty("Premise")]
    public virtual ICollection<LocalDemographicIssue> LocalDemographicIssues { get; set; } = new List<LocalDemographicIssue>();

    [InverseProperty("Premise")]
    public virtual ICollection<LocalHotel> LocalHotels { get; set; } = new List<LocalHotel>();

    [InverseProperty("Premise")]
    public virtual ICollection<LocationOpenDay> LocationOpenDays { get; set; } = new List<LocationOpenDay>();

    [InverseProperty("Premise")]
    public virtual ICollection<LocationType> LocationTypes { get; set; } = new List<LocationType>();

    [InverseProperty("Premise")]
    public virtual ICollection<MinorWork> MinorWorks { get; set; } = new List<MinorWork>();

    [InverseProperty("Premise")]
    public virtual ICollection<OutreachLocation> OutreachLocations { get; set; } = new List<OutreachLocation>();

    [InverseProperty("Premise")]
    public virtual ICollection<PremiseRate> PremiseRates { get; set; } = new List<PremiseRate>();

    [InverseProperty("Premise")]
    public virtual ICollection<Volunteering> Volunteerings { get; set; } = new List<Volunteering>();
}
