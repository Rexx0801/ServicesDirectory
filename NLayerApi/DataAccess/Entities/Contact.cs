using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Contact")]
public class Contact
{
    [Key]
    public Guid ContactId { get; set; }

    [StringLength(100)]
    public string? ContactName { get; set; }

    [StringLength(15)]
    public string? MobilePhone { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(100)]
    public string? ContactType { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Contact")]
    public virtual ICollection<Organisation> Organisations { get; set; } = new List<Organisation>();

    [InverseProperty("Contact")]
    public virtual ICollection<Premise> Premises { get; set; } = new List<Premise>();
}
