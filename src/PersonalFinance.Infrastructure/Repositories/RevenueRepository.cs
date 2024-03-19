using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Infrastructure.Context;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Infrastructure.Repositories;

public class RevenueRepository : IRevenueRepository
{
    private readonly AppDbContext _dbContext;

    public RevenueRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask<Revenue> GetByIdAndUserIdAsync(long id, long userId)
    {
        return await this._dbContext.Revenues
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
    }

    public async ValueTask<IEnumerable<Revenue>> GetByUserIdAsync(long userId)
    {
        return await this._dbContext.Revenues.Where(x => x.UserId == userId).ToListAsync();
    }

    public async ValueTask AddAsync(Revenue revenue)
    {
        await this._dbContext.Revenues.AddAsync(revenue);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(Revenue revenue)
    {
        this._dbContext.Revenues.Update(revenue);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(Revenue revenue)
    {
        this._dbContext.Revenues.Remove(revenue);
        await this._dbContext.SaveChangesAsync();
    }
}