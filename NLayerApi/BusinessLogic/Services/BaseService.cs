using BusinessLayer.Interfaces;
using DataAccess.Repositories;

namespace BusinessLayer.Services;

public class BaseService<T, TEntity>(IGenericRepository<TEntity> genericRepository, AutoMapper.Mapper mapper)
    : IBaseService<T>
    where T : class
    where TEntity : class
{
    public IEnumerable<T> GetAll()
    {
        IEnumerable<TEntity> entities = genericRepository.GetAll();
        return entities.Select(mapper.Map<T>);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        IEnumerable<TEntity> entities = await genericRepository.GetAllAsync();
        return entities.Select(mapper.Map<T>);
    }

    public T? GetById(Guid id)
    {
        TEntity? entity = genericRepository.GetById(id);
        return mapper.Map<T>(entity);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        TEntity? entity = await genericRepository.GetByIdAsync(id);
        return mapper.Map<T>(entity);
    }

    public void Add(T entity)
    {
        genericRepository.Add(mapper.Map<TEntity>(entity));
    }

    public void Update(T entity)
    {
        genericRepository.Update(mapper.Map<TEntity>(entity));
    }

    public void Delete(Guid id)
    {
        genericRepository.Delete(id);
    }

    public void Delete(T entity)
    {
        genericRepository.Delete(mapper.Map<TEntity>(entity));
    }
}