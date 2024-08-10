using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Volunteering")]
public class Volunteering
{
    [Key]
    public Guid VolunteeringId { get; set; }

    [StringLength(255)]
    public string VolunteeringContact { get; set; } = null!;

    [StringLength(255)]
    public string? VolunteeringPurpose { get; set; }

    [StringLength(255)]
    public string? VolunteeringOpportunityDetails { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? VolunteerNos { get; set; }

    public bool? IsActive { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("Volunteerings")]
    public virtual Premise Premise { get; set; } = null!;
}
