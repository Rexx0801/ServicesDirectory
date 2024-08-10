using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Country")]
public class Country
{
    [Key]
    public Guid CountryId { get; set; }

    [StringLength(100)]
    public string? CountryName { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<County> Counties { get; set; } = new List<County>();
}
