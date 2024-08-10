using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Accreditation")]
public class Accreditation
{
    [Key]
    public Guid AccreditationId { get; set; }

    [StringLength(100)]
    public string? AccreditationName { get; set; }

    public Guid? PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("Accreditations")]
    public virtual Premise? Premise { get; set; }
}
