using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Organisation")]
public class Organisation
{
    [Key]
    public Guid OrganisationId { get; set; }

    [StringLength(100)]
    public string OrganisationName { get; set; } = null!;

    [StringLength(100)]
    public string? HeadOfficeAddress { get; set; }

    [StringLength(100)]
    public string? Postcode { get; set; }

    public bool? IsActive { get; set; }

    public Guid ContactId { get; set; }

    [ForeignKey("ContactId")]
    [InverseProperty("Organisations")]
    public virtual Contact Contact { get; set; } = null!;
}
