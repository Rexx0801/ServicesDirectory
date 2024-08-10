using AutoMapper;
using BusinessLayer.Interfaces;
using Common.Dto;
using DataAccess.Repositories;

namespace BusinessLayer.Services
{
    public class PremiseService : IPremiseService
    {
        private readonly IMapper _mapper;
        private readonly IPremiseRepository _premiseRepository;

        public PremiseService(IMapper mapper, IPremiseRepository premiseRepository)
        {
            _mapper = mapper;
            _premiseRepository = premiseRepository;
        }

        public IEnumerable<PremiseDto> GetPremises(bool includeInactive, string filter)
        {
            var premises = _premiseRepository.GetPremises(includeInactive, filter);
            return _mapper.Map<IEnumerable<PremiseDto>>(premises);
        }

        public PremiseDto GetPremiseById(Guid id)
        {
            var premise = _premiseRepository.GetPremiseById(id);
            return _mapper.Map<PremiseDto>(premise);
        }

        public bool ActivatePremise(Guid id)
        {
            var premise = _premiseRepository.GetPremiseById(id);
            if (premise == null || premise.IsActive == true)
            {
                return false;
            }
            premise.IsActive = true;
            _premiseRepository.UpdatePremise(premise);
            return true;
        }
        public bool DeactivatePremise(Guid id)
        {
            var premise = _premiseRepository.GetPremiseById(id);
            if (premise == null || premise.IsActive == false)
            {
                return false;
            }
            premise.IsActive = false;
            _premiseRepository.UpdatePremise(premise);
            return true;
        }
        public IEnumerable<PremiseDto> GetNewPremises()
        {
            var premises = _premiseRepository.GetNewPremises();
            var premiseDtos = _mapper.Map<IEnumerable<PremiseDto>>(premises);

            foreach (var premise in premises)
            {
                if (premise.LocationTypes.Any(lt => lt.LocationName == "Shop") &&
                    premise.ShopFlagDate.HasValue &&
                    (DateTime.Now - premise.ShopFlagDate.Value.ToDateTime(TimeOnly.MinValue)).TotalDays <= 60)
                {
                    premise.IsNewShop = true;
                }
                else
                {
                    premise.IsNewShop = false;
                }
                _premiseRepository.UpdatePremise(premise);
            }

            return _mapper.Map<IEnumerable<PremiseDto>>(premises);
        }
        public IEnumerable<PremiseDto> FilterPremises(string filter)
        {
            var premises = _premiseRepository.FilterPremises(filter);
            return _mapper.Map<IEnumerable<PremiseDto>>(premises);
        }

        public IEnumerable<PremiseDto> SortPremises(string columnName)
        {
            var premises = _premiseRepository.SortPremises(columnName);
            return _mapper.Map<IEnumerable<PremiseDto>>(premises);
        }



        public IEnumerable<PremiseDto> GetAllPremises(bool includeInactive)
        {
            var premises = _premiseRepository.GetAllPremises(includeInactive);
            return _mapper.Map<IEnumerable<PremiseDto>>(premises);
        }
    }
}
