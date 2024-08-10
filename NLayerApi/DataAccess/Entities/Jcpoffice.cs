using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("JcpOffice")]
public class JcpOffice
{
    [Key]
    public Guid JcpOfficeId { get; set; }

    [StringLength(100)]
    public string? JcpOfficeName { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("JCPOffices")]
    public virtual Premise Premise { get; set; } = null!;
}
