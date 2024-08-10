using Common.Dto;
using DataAccess.Entities;

namespace BusinessLayer.Interfaces;

public interface IMinorWorkService
{
    public IEnumerable<MinorWorkDto> Gets(string? sortOrder);
    public MinorWorkDto Get(Guid id);
    public MinorWork AddMinorWork(MinorWorkDto minorWorkDto);
    public void UpdateMinorWork(MinorWorkDto newMinorWork);
    public void DeleteMinorWork(Guid id);
}