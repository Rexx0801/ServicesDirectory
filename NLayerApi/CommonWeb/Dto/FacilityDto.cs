namespace Common.Dto;

public class FacilityDto
{
    public Guid FacilityId { get; set; }
    public string FacilityType { get; set; } = null!;
    public string FacilityDescription { get; set; } = null!;
    public int? RoomCapacity { get; set; }
    public int? RoomSize { get; set; }
    public string? ConnectivityType { get; set; }
    public string? WirelessAccessInformation { get; set; }
    public string? LeadContact { get; set; }
    public string? RoomHost { get; set; }
    public string? RoomAndEquipmentNotes { get; set; }
    public Guid PremiseId { get; set; }
    public bool? IsActive { get; set; }
}

