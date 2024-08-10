using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("PremiseRate")]
public class PremiseRate
{
    [Key]
    public Guid PrimiseRateId { get; set; }

    public double? RoomOnlyRate { get; set; }

    public double? BBRate { get; set; }

    public double? DBBRate { get; set; }

    public double? DDRate { get; set; }

    public double? Rate24hr { get; set; }

    public double? TeaAndCoofee { get; set; }

    public bool? Lunch { get; set; }

    public int? NoOfMeetingRooms { get; set; }

    public double? MeetingRoomRatePerDay { get; set; }

    [StringLength(50)]
    public string? Codings { get; set; }

    public double? NegotiatedRoomOnlyRate { get; set; }

    public double? BBNegotiatedRate { get; set; }

    public double? DBBNegotiatedRate { get; set; }

    public double? RateNegoteated24hr { get; set; }

    public DateOnly? LastNegotiatedDate { get; set; }

    public DateOnly? ReNegotiateOn { get; set; }

    [StringLength(100)]
    public string? PreferredStatus { get; set; }

    [StringLength(255)]
    public string? Comments { get; set; }

    public Guid PremiseId { get; set; }

    [ForeignKey("PremiseId")]
    [InverseProperty("PremiseRates")]
    public virtual Premise Premise { get; set; } = null!;
}
