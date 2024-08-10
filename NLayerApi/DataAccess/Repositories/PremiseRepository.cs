using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class PremiseRepository : IPremiseRepository
    {
        private readonly Team04DbContext _context;

        public PremiseRepository(Team04DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Premise> GetPremises(bool includeInactive, string filter)
        {
            var query = _context.Premises
                .Include(p => p.Address)
                 .Include(p => p.LocationTypes)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(p => p.IsActive == true);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(p => p.LocationName.StartsWith(filter));
            }

            return query.ToList();
        }

        public Premise GetPremiseById(Guid id)
        {
            return _context.Premises
                .Include(p => p.Address)
                .FirstOrDefault(p => p.PremiseId == id);
        }

        public void UpdatePremise(Premise premise)
        {
            _context.Premises.Update(premise);
            _context.SaveChanges();
        }

        public IEnumerable<Premise> FilterPremises(string filter)
        {
            IQueryable<Premise> query = _context.Premises.Include(p => p.Address);

            if (string.IsNullOrEmpty(filter) || filter == "All")
            {
                return query.ToList();
            }
            else if (filter == "0-9")
            {
                query = query.Where(p => p.LocationName.Any() && char.IsDigit(p.LocationName[0]));
            }
            else
            {
                query = query.Where(p => p.LocationName.Any() && filter.Contains(p.LocationName[0]));
            }

            return query.ToList();
        }

        public IEnumerable<Premise> SortPremises(string columnName)
        {
            var query = _context.Premises
                .Include(p => p.Address)
                .AsQueryable();

            switch (columnName)
            {
                case "LocationName":
                    query = query.OrderBy(p => p.LocationName);
                    break;
                case "AddressLine1":
                    query = query.OrderBy(p => p.Address.AddressLine1);
                    break;
                case "PostCode":
                    query = query.OrderBy(p => p.Address.PostCode);
                    break;
                case "IsActive":
                    query = query.OrderBy(p => p.IsActive);
                    break;
                default:
                    query = query.OrderBy(p => p.PremiseId);
                    break;
            }

            return query.ToList();
        }

        public IEnumerable<Premise> GetNewPremises()
        {
            return _context.Premises
                .Include(p => p.Address)
                .Include(p => p.LocationTypes)
                .AsEnumerable()
                .ToList();
        }

        public IEnumerable<Premise> GetAllPremises(bool includeInactive)
        {
            var query = _context.Premises
                .Include(p => p.Address)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(p => p.IsActive == true);
            }

            return query.ToList();
        }
    }
}
