using Common.Dto;
using DataAccess.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IVolunteeringService
    {
        IEnumerable<VolunteeringDto> Gets();
        VolunteeringDto Get(Guid id);
        Volunteering AddVolunteering(VolunteeringDto volunteeringDto);
        void UpdateVolunteering(VolunteeringDto newVolunteering);
        void DeleteVolunteering(Guid id);
    }
}
