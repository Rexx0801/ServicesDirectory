using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class GenericRepository<T>(DbContext context) : IGenericRepository<T>
    where T : class
{
    public IEnumerable<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public T? GetById(Guid id)
    {
        return context.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        context.Set<T>().Remove(GetById(id)!);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }
}