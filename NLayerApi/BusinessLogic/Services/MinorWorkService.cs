using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using DataAccess.Data;
using DataAccess.Entities;

namespace BusinessLayer.Services
{
    public class MinorWorkService : IMinorWorkService
    {
        private readonly Team04DbContext _context;
        private readonly IMapper _mapper;

        public MinorWorkService(Team04DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MinorWork AddMinorWork(MinorWorkDto minorWorkDto)
        {
            MinorWork minorWork = _mapper.Map<MinorWork>(minorWorkDto);
            if (minorWorkDto.AuthorisedDate < minorWorkDto.EnqReceivedDate
                || minorWorkDto.ActualStartDate < minorWorkDto.AuthorisedDate
                || minorWorkDto.ActualCompletionDate < minorWorkDto.EnqReceivedDate
                || minorWorkDto.ActualCompletionDate < minorWorkDto.ActualStartDate)
            {
                throw new ArgumentException("Invalid date sequence");
            }
            _context.MinorWorks.Add(minorWork);
            _context.SaveChanges();
            return minorWork;
        }

        public void DeleteMinorWork(Guid id)
        {
            var minor = _context.MinorWorks.FirstOrDefault(m => m.MinorWorkId == id);
            if (minor == null)
            {
                throw new ArgumentException("Minor work not found");
            }

            minor.IsActive = false;
            _context.MinorWorks.Update(minor);
            _context.SaveChanges();
        }

        public MinorWorkDto Get(Guid id)
        {
            var minorWork = _context.MinorWorks.Find(id);
            return _mapper.Map<MinorWorkDto>(minorWork);
        }

        public IEnumerable<MinorWorkDto> Gets(string? sortOrder)
        {
            var activeMinorWorks = _context.MinorWorks.Where(mw => mw.IsActive == true);

            switch (sortOrder?.ToLower())
            {
                case "desc":
                    activeMinorWorks = activeMinorWorks.OrderByDescending(mw => mw.Description);
                    break;
                case "asc":
                    activeMinorWorks = activeMinorWorks.OrderBy(mw => mw.Description);
                    break;
                default:
                    activeMinorWorks = activeMinorWorks.OrderBy(mw => mw.Description);
                    break;
            }

            return _mapper.Map<IEnumerable<MinorWorkDto>>(activeMinorWorks.ToList());
        }


        public void UpdateMinorWork(MinorWorkDto newMinorWork)
        {
            var existingMinorWork = _context.MinorWorks.Find(newMinorWork.MinorWorkId);
            if (existingMinorWork != null && existingMinorWork.IsActive == true)
            {
                _mapper.Map(newMinorWork, existingMinorWork);
                _context.MinorWorks.Update(existingMinorWork);
                _context.SaveChanges();
            }
        }
    }
}