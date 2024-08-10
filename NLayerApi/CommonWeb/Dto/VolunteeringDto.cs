using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class VolunteeringDto
    {
        public Guid VolunteeringId { get; set; }

        [StringLength(255)]
        public string VolunteeringContact { get; set; } = null!;

        [StringLength(255)]
        public string? VolunteeringPurpose { get; set; }

        [StringLength(255)]
        public string? VolunteeringOpportunityDetails { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? VolunteerNos { get; set; }

        public bool? IsActive { get; set; }

        public Guid PremiseId { get; set; }
        public Premise? Premise { get; set; }
    }
}

