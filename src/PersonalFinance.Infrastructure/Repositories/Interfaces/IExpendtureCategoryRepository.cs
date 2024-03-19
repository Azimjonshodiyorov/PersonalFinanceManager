using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Repositories.Interfaces;

public interface IExpendtureCategoryRepository
{
    ValueTask<ExpenditureCategory> GetByIdAndUserIdAsync(long id, long userId);
    ValueTask<ExpenditureCategory> GetByIdAndUserIdAsNoTrackingAsync(long id, long userId);
    ValueTask<IEnumerable<ExpenditureCategory>> GetByUserIdAsNoTrackingAsync(long userId);
    ValueTask AddAsync(ExpenditureCategory expenditureCategory);
    ValueTask UpdateAsync(ExpenditureCategory expenditureCategory);
    ValueTask DeleteAsync(ExpenditureCategory expenditureCategory);
}