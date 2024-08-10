using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Facility
{
    [Key]
    public Guid FacilityId { get; set; }

    [StringLength(100)]
    public string FacilityType { get; set; } = null!;

    [StringLength(255)]
    public string FacilityDescription { get; set; } = null!;

    public int? RoomCapacity { get; set; }

    public int? RoomSize { get; set; }

    [StringLength(100)]
    public string? ConnectivityType { get; set; }

    [StringLength(255)]
    public string? WirelessAccessInformation { get; set; }

    [StringLength(100)]
    public string? LeadContact { get; set; }

    [StringLength(100)]
    public string? RoomHost { get; set; }

    [StringLength(255)]
    public string? RoomAndEquipmentNotes { get; set; }

    public Guid PremiseId { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("Facilities")]
    public virtual Premise Premise { get; set; } = null!;
}
