using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("OutreachLocation")]
public class OutreachLocation
{
    [Key]
    public Guid OutreachLocationId { get; set; }

    [StringLength(100)]
    public string? OuttreachLocationName { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("OutreachLocations")]
    public virtual Premise Premise { get; set; } = null!;
}
