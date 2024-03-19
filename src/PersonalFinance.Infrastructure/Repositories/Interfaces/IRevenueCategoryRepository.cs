using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Repositories.Interfaces;

public interface IRevenueCategoryRepository
{
    ValueTask<RevenueCategory> GetByIdAndUserIdAsync(long id, long userId);
    ValueTask<RevenueCategory> GetByIdAndUserIdAsNoTrackingAsync(long id, long userId);
    ValueTask<IEnumerable<RevenueCategory>> GetByUserIdAsNoTrackingAsync(long userId);
    ValueTask AddAsync(RevenueCategory revenueCategory);
    ValueTask UpdateAsync(RevenueCategory revenueCategory);
    ValueTask DeleteAsync(RevenueCategory revenueCategory);
}