using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class LocalDemographicIssue
{
    [Key]
    public Guid LocalDemographicIssuesId { get; set; }

    [StringLength(100)]
    public string? LocalDemographicIssuesName { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("LocalDemographicIssues")]
    public virtual Premise Premise { get; set; } = null!;
}
