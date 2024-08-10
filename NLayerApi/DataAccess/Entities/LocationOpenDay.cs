using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("LocationOpenDay")]
public class LocationOpenDay
{
    [Key]
    public Guid LocationOpenDayId { get; set; }

    [StringLength(50)]
    public string WeekendDay { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    public bool? IsActive { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("LocationOpenDays")]
    public virtual Premise Premise { get; set; } = null!;
}
