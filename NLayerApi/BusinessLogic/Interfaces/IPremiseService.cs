using Common.Dto;

namespace BusinessLayer.Interfaces;

public interface IPremiseService
{
    IEnumerable<PremiseDto> GetPremises(bool includeInactive, string filter);
    PremiseDto GetPremiseById(Guid id);
    bool ActivatePremise(Guid id);
    bool DeactivatePremise(Guid id);
    IEnumerable<PremiseDto> FilterPremises(string filter);
    IEnumerable<PremiseDto> SortPremises(string columnName);
    IEnumerable<PremiseDto> GetNewPremises();
    IEnumerable<PremiseDto> GetAllPremises(bool includeInactive);
}
