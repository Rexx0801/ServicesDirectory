using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace DataAccess.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly Team04DbContext _context;

        public FacilityRepository(Team04DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Facility>> GetAllAsync(string filter, string sort)
        {
            IQueryable<Facility> query = _context.Facilities.AsNoTracking();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(f => f.FacilityType.Contains(filter) ||
                                         f.FacilityDescription.Contains(filter) ||
                                         f.LeadContact.Contains(filter) ||
                                         f.RoomHost.Contains(filter));
            }

            if (!string.IsNullOrEmpty(sort))
            {
                // Validate sort parameter to prevent SQL injection
                var sortProperties = new List<string> { "FacilityType", "RoomCapacity", "RoomSize", "LeadContact", "RoomHost" };
                var sortParams = sort.Split(' ');

                if (sortProperties.Contains(sortParams[0], StringComparer.OrdinalIgnoreCase))
                {
                    query = query.OrderBy($"{sortParams[0]} {(sortParams.Length > 1 ? sortParams[1] : "asc")}");
                }
                else
                {
                    throw new ArgumentException("Invalid sort parameter");
                }
            }

            return await query.ToListAsync();
        }

        public async Task<Facility> GetByIdAsync(Guid id)
        {
            var facility = await _context.Facilities.AsNoTracking().FirstOrDefaultAsync(f => f.FacilityId == id);
            if (facility == null)
            {
                throw new KeyNotFoundException("Facility not found");
            }
            return facility;
        }

        public async Task AddAsync(Facility facility)
        {
            facility.FacilityId = Guid.NewGuid();
            await _context.Facilities.AddAsync(facility);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Facility facility)
        {
            var existingFacility = await _context.Facilities.FindAsync(facility.FacilityId);
            if (existingFacility == null)
            {
                throw new KeyNotFoundException("Facility not found");
            }

            _context.Entry(existingFacility).CurrentValues.SetValues(facility);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsInactiveAsync(Guid id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility != null)
            {
                facility.IsActive = false;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Facility not found");
            }
        }
    }
}
