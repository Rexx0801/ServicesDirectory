using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("LocationType")]
public class LocationType
{
    [Key]
    public Guid LocationTypeId { get; set; }

    [StringLength(100)]
    public string? LocationName { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("LocationTypes")]
    public virtual Premise Premise { get; set; } = null!;
}
