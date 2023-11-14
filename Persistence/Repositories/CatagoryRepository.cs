using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Persistence.Repositoties;
public class CatagoryRepository: GenericRespositoty<Category>, ICatagoryRepository
{
    private readonly AssesmentApiDbContext _context;
    public CatagoryRepository(AssesmentApiDbContext context) :base(context)
    {
        _context =context;
    }

    public async Task<Category> GetNameAsync(string Name)
    {
        var result = await _context.Categories.FirstOrDefaultAsync(x=> x.Name == Name);
        return result;
    }

   
}