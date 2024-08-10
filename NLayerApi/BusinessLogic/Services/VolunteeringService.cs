using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using DataAccess.Data;
using DataAccess.Entities;

namespace BusinessLayer.Services
{
    public class VolunteeringService : IVolunteeringService
    {
        private readonly Team04DbContext _context;
        private readonly IMapper _mapper;

        public VolunteeringService(Team04DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Volunteering AddVolunteering(VolunteeringDto volunteeringDto)
        {
            try
            {
                Volunteering volunteering = _mapper.Map<Volunteering>(volunteeringDto);
                volunteering.VolunteeringId = Guid.NewGuid();
                if (volunteeringDto.EndDate < volunteeringDto.StartDate)
                {
                    throw new ArgumentException("End date cannot be before start date");
                }
                _context.Volunteerings.Add(volunteering);
                _context.SaveChanges();

                return volunteering;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteVolunteering(Guid id)
        {
            var volunteering = _context.Volunteerings.SingleOrDefault(v => v.VolunteeringId == id);
            if (volunteering == null)
            {
                throw new ArgumentException("Volunteering opportunity not found");
            }

            volunteering.IsActive = false;
            _context.Volunteerings.Update(volunteering);
            _context.SaveChanges();
        }

        public VolunteeringDto Get(Guid id)
        {
            var volunteering = _context.Volunteerings
                .FirstOrDefault(v => v.VolunteeringId == id);
            return _mapper.Map<VolunteeringDto>(volunteering);
        }

        public IEnumerable<VolunteeringDto> Gets()
        {
            var activeVolunteerings = _context.Volunteerings
                .Where(v => v.IsActive == true).ToList();
            return _mapper.Map<IEnumerable<VolunteeringDto>>(activeVolunteerings);
        }

        public void UpdateVolunteering(VolunteeringDto newVolunteering)
        {
            var existingVolunteering = _context.Volunteerings.Find(newVolunteering.VolunteeringId);
            if (existingVolunteering != null && existingVolunteering.IsActive == true)
            {
                if (newVolunteering.EndDate < newVolunteering.StartDate)
                {
                    throw new ArgumentException("End date cannot be before start date");
                }
                _mapper.Map(newVolunteering, existingVolunteering);
                _context.Volunteerings.Update(existingVolunteering);
                _context.SaveChanges();
            }
        }
    }
}
