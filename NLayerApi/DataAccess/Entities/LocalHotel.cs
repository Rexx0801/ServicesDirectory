using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class LocalHotel
{
    [Key]
    public Guid LocalHotelId { get; set; }

    [StringLength(100)]
    public string? LocalHotelName { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("LocalHotels")]
    public virtual Premise Premise { get; set; } = null!;
}
