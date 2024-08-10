namespace BusinessLayer.Interfaces;

public interface IBaseService<T>
{
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    T? GetById(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    void Add(T entity);
    void Update(T entity);
    void Delete(Guid id);
    void Delete(T entity);
}