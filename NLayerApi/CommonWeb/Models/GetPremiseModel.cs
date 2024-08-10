namespace Common.Models;

public class GetPremiseModel
{
    public string PremiseId { get; set; } = null!;
    public string PremiseName { get; set; } = null!;
    public string? LocationType { get; set; }
    public string? LocationOrganization { get; set; }
    public DateTime? LocationOpenDay { get; set; }
    public string? Postcode { get; set; }
    public string AddressId { get; set; } = null!;
    public string? Status { get; set; }
    public string ServiceId { get; set; } = null!;
}
