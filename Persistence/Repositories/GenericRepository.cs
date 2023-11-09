

using Assesment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Persistence.Repositoties;

public class GenericRespositoty<T> : IGenericRepository<T> where T : class 
{
    private readonly AssesmentApiDbContext _dbcontext;

    public GenericRespositoty(AssesmentApiDbContext context)
    {
        _dbcontext = context;
    
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbcontext.AddAsync(entity);
        await _dbcontext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T  entity)
    {
        _dbcontext.Set<T>().Remove(entity);
        await _dbcontext.SaveChangesAsync();

    }

  

    public async Task<T> GetAsync(int id)
    {
        var entity = await _dbcontext.Set<T>().FindAsync(id);
        return entity!;
    }

    public async Task<List<T>> GetAsync()
    {
        return await _dbcontext.Set<T>().ToListAsync();

    }

 
    public async Task<T> UpdateAsync(T entity)
    {
        _dbcontext.Entry(entity).State = EntityState.Modified;
        await _dbcontext.SaveChangesAsync();
        return entity;

    }

}