using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Infrastructure.Context;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Infrastructure.Repositories;

public class ExpendtureRepository : IExpendtureRepository
{
    private readonly AppDbContext _dbContext;

    public ExpendtureRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask<Expenditure> GetByIdAndUserIdAsync(long id, long userId)
    {
        return await this._dbContext.Expenditures.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
    }

    public async ValueTask<IEnumerable<Expenditure>> GetByUserIdAsync(long userId)
    {
        return await this._dbContext.Expenditures.Where(x => x.UserId == userId).ToListAsync();
    }

    public async ValueTask AddAsync(Expenditure expenditure)
    {
        await this._dbContext.Expenditures.AddAsync(expenditure);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(Expenditure expenditure)
    {
         this._dbContext.Expenditures.Update(expenditure);
         await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(Expenditure expenditure)
    {
        this._dbContext.Expenditures.Remove(expenditure);
        await this._dbContext.SaveChangesAsync();
    }
}