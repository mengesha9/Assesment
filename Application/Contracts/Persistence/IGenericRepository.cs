namespace Assesment.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    
    Task<T> GetAsync(int id);
    Task<List<T>> GetAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}