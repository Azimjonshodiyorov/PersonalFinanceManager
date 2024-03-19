using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Repositories.Interfaces;

public interface IRevenueRepository
{
    ValueTask<Revenue> GetByIdAndUserIdAsync(long id, long userId);
    ValueTask<IEnumerable<Revenue>> GetByUserIdAsync(long userId);
    ValueTask AddAsync(Revenue revenue);
    ValueTask UpdateAsync(Revenue revenue);
    ValueTask DeleteAsync(Revenue revenue);
    
}