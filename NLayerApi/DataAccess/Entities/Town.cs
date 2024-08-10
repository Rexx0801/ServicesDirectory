using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Town")]
public class Town
{
    [Key]
    public Guid TownId { get; set; }

    [StringLength(100)]
    public string? TownName { get; set; }

    public Guid CountyId { get; set; }

    [InverseProperty("Town")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [ForeignKey("CountyId")]
    [InverseProperty("Towns")]
    public virtual County County { get; set; } = null!;
}
