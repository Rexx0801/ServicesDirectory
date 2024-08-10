using Common.Dto;

namespace BusinessLayer.Interfaces

{
    public interface IFacilityService
    {

        Task<IEnumerable<FacilityDto>> GetAllFacilitiesAsync(string filter, string sort);
        Task<FacilityDto> GetFacilityByIdAsync(Guid id);
        Task AddFacilityAsync(FacilityDto facility);
        Task UpdateFacilityAsync(FacilityDto facility);
        Task MarkFacilityAsInactiveAsync(Guid id);
    }
}
