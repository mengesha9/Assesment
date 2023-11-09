using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Persistence.Repositoties;
public class CatagoryRepository: GenericRespositoty<Catagory>, ICatagoryRepository
{
    private readonly AssesmentApiDbContext _context;
    public CatagoryRepository(AssesmentApiDbContext context) :base(context)
    {
        _context =context;
    }


    public async Task<Catagory> GetNameAsync(string Name)
    {
        var result = await _context.Catagories.FirstOrDefaultAsync(x=> x.Name == Name);
        
        return result;
    }

}