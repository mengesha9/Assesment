using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Assesment.Persistence.Repositoties;
namespace Assesment.Persistence.Repositories;
public class UserRepository : GenericRespositoty<User>, IUserRepository
{
    private readonly AssesmentApiDbContext _dbContext;
    public UserRepository(AssesmentApiDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> EmailExists(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email == email);
    }

    public async Task<User> GetByEmail(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        return user!;

    }

    public async Task<User> GetByUsername(string Name)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Name == Name);
        return user!;
    }

    public async Task<bool> UsernameExists(string Name)
    {
        return await _dbContext.Users.AnyAsync(user => user.Name == Name);
    }


}
