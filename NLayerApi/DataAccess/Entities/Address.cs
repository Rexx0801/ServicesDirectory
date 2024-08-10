using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Address")]
public class Address
{
    [Key]
    public Guid AddressId { get; set; }

    [StringLength(50)]
    public string PostCode { get; set; } = null!;

    [StringLength(100)]
    public string AddressLine1 { get; set; } = null!;

    [StringLength(100)]
    public string? AddressLine2 { get; set; }

    [StringLength(100)]
    public string? AddressLine3 { get; set; }

    public Guid TownId { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<Premise> Premises { get; set; } = new List<Premise>();

    [ForeignKey("TownId")]
    [InverseProperty("Addresses")]
    public virtual Town Town { get; set; } = null!;
}
