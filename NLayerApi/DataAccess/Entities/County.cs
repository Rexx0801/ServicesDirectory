using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("County")]
public class County
{
    [Key]
    public Guid CountyId { get; set; }

    [StringLength(100)]
    public string? CountyName { get; set; }

    public Guid CountryId { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("Counties")]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty("County")]
    public virtual ICollection<Town> Towns { get; set; } = new List<Town>();
}
