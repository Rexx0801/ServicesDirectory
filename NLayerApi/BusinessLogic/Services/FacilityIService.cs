using AutoMapper;
using Common.Dto;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace BusinessLayer.Interfaces

{
    public class FacilityIService : IFacilityService
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public FacilityIService(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }
        //them filter va sort
        public async Task<IEnumerable<FacilityDto>> GetAllFacilitiesAsync(string filter, string sort)
        {
            var facilities = await _facilityRepository.GetAllAsync(filter, sort);
            return _mapper.Map<IEnumerable<FacilityDto>>(facilities);
        }

        public async Task<FacilityDto> GetFacilityByIdAsync(Guid id)
        {
            var facility = await _facilityRepository.GetByIdAsync(id);
            return _mapper.Map<FacilityDto>(facility);
        }

        public async Task AddFacilityAsync(FacilityDto facility)
        {
            var entity = _mapper.Map<Facility>(facility);
            await _facilityRepository.AddAsync(entity);
        }

        public async Task UpdateFacilityAsync(FacilityDto facility)
        {
            var entity = _mapper.Map<Facility>(facility);
            await _facilityRepository.UpdateAsync(entity);
        }

        public async Task MarkFacilityAsInactiveAsync(Guid id)
        {
            var facility = await _facilityRepository.GetByIdAsync(id);
            if (facility != null)
            {
                facility.IsActive = false;
                await _facilityRepository.UpdateAsync(facility);
            }
        }
    }
}
