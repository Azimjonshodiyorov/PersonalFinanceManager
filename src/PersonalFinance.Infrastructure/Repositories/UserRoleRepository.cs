using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Infrastructure.Context;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _dbContext;

    public UserRoleRepository( AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async ValueTask<UserRole> GetByIdAsync(long id)
    {
        return await this._dbContext.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<UserRole> GetByIdAsNoTrackingAsync(long id)
    {
        return await this._dbContext.UserRoles.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<IEnumerable<UserRole>> GetAllAsNoTrackingAsync()
    {
        return  await this._dbContext.UserRoles.AsTracking().ToListAsync();
    }

    public async ValueTask AddAsync(UserRole userRole)
    {
        await this._dbContext.UserRoles.AddAsync(userRole);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(UserRole userRole)
    {
        this._dbContext.UserRoles.Update(userRole);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(UserRole userRole)
    {
        this._dbContext.UserRoles.Remove(userRole);
        await this._dbContext.SaveChangesAsync();
    }
}