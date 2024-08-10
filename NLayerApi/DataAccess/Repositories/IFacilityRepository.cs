using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IFacilityRepository
    {
        //them filter va sort
        Task<IEnumerable<Facility>> GetAllAsync(string filter, string sort);
        Task<Facility> GetByIdAsync(Guid id);
        Task AddAsync(Facility facility);
        Task UpdateAsync(Facility facility);
        Task MarkAsInactiveAsync(Guid id);
    }
}
