using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface IPremiseRepository
{
    IEnumerable<Premise> GetPremises(bool includeInactive, string filter);
    Premise GetPremiseById(Guid id);
    void UpdatePremise(Premise premise);
    IEnumerable<Premise> FilterPremises(string filter);
    IEnumerable<Premise> SortPremises(string columnName);
    IEnumerable<Premise> GetNewPremises();
    IEnumerable<Premise> GetAllPremises(bool includeInactive);
}