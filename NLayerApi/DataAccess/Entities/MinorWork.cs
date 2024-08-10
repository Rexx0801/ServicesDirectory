using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class MinorWork
{
    [Key]
    public Guid MinorWorkId { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    public bool? IsMinorWorks { get; set; }

    [StringLength(255)]
    public string? NotesActions { get; set; }

    public double? EstimatedCost { get; set; }

    public double? ActualCost { get; set; }

    [StringLength(255)]
    public string? Directorate { get; set; }

    [StringLength(255)]
    public string? Contact { get; set; }

    [StringLength(255)]
    public string? AuthorisedByName { get; set; }

    public bool Status { get; set; }

    public DateTime? EnqReceivedDate { get; set; }

    public DateTime? AuthorisedDate { get; set; }

    public DateTime? ActualStartDate { get; set; }

    public DateTime? AnticipatedCompletion { get; set; }

    public DateTime? ActualCompletionDate { get; set; }

    public bool? IsActive { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("MinorWorks")]
    public virtual Premise Premise { get; set; } = null!;
}
