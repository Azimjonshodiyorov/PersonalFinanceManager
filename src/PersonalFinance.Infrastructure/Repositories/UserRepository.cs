using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Infrastructure.Context;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask<User> GetByIdAsync(long id)
    {
        return await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<User> GetByEmailAsync(string email)
    {
        return await this._dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async ValueTask<IEnumerable<User>> GetAllAsync()
    {
        return await this._dbContext.Users.ToListAsync();
    }

    public async ValueTask AddAsync(User user)
    {
        await this._dbContext.Users.AddAsync(user);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(User user)
    {
         this._dbContext.Users.Update(user);
         await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(User user)
    {
        this._dbContext.Users.Remove(user);
        await this._dbContext.SaveChangesAsync();
    }
}