using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Infrastructure.Context;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Infrastructure.Repositories;

public class ExpendtureCategoryRepository : IExpendtureCategoryRepository
{
    private readonly AppDbContext _dbContext;

    public ExpendtureCategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask<ExpenditureCategory> GetByIdAndUserIdAsync(long id, long userId)
    {
        return await this._dbContext.ExpenditureCategories
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
    }

    public async ValueTask<ExpenditureCategory> GetByIdAndUserIdAsNoTrackingAsync(long id, long userId)
    {
        return await this._dbContext.ExpenditureCategories.AsTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
    }

    public async ValueTask<IEnumerable<ExpenditureCategory>> GetByUserIdAsNoTrackingAsync(long userId)
    {
        return await this._dbContext.ExpenditureCategories.AsTracking().Where(x => x.UserId == userId).ToListAsync();
    }

    public async ValueTask AddAsync(ExpenditureCategory expenditureCategory)
    {
        await this._dbContext.ExpenditureCategories.AddAsync(expenditureCategory);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(ExpenditureCategory expenditureCategory)
    {
        this._dbContext.ExpenditureCategories.Update(expenditureCategory);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(ExpenditureCategory expenditureCategory)
    {
        this._dbContext.ExpenditureCategories.Remove(expenditureCategory);
        await this._dbContext.SaveChangesAsync();
    }
}