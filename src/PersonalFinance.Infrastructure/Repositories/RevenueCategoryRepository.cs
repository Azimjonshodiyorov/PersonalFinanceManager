using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Infrastructure.Context;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Infrastructure.Repositories;

public class RevenueCategoryRepository : IRevenueCategoryRepository
{
    private readonly AppDbContext _dbContext;

    public RevenueCategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask<RevenueCategory> GetByIdAndUserIdAsync(long id, long userId)
    {
        return await this._dbContext.RevenueCategories.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
    }

    public async ValueTask<RevenueCategory> GetByIdAndUserIdAsNoTrackingAsync(long id, long userId)
    {
        return await this._dbContext.RevenueCategories.AsTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
    }

    public async ValueTask<IEnumerable<RevenueCategory>> GetByUserIdAsNoTrackingAsync(long userId)
    {
        return await this._dbContext.RevenueCategories.AsTracking().Where(x => x.UserId == userId).ToListAsync();
    }

    public async ValueTask AddAsync(RevenueCategory revenueCategory)
    {
        await this._dbContext.RevenueCategories.AddAsync(revenueCategory);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(RevenueCategory revenueCategory)
    {
        this._dbContext.RevenueCategories.Update(revenueCategory);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(RevenueCategory revenueCategory)
    {
        this._dbContext.RevenueCategories.Remove(revenueCategory);
        await this._dbContext.SaveChangesAsync();
    }
}