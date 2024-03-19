using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Repositories.Interfaces;

public interface IExpendtureRepository
{
    ValueTask<Expenditure> GetByIdAndUserIdAsync(long id, long UserId);
    ValueTask<IEnumerable<Expenditure>> GetByUserIdAsync(long UserId);
    ValueTask AddAsync(Expenditure expenditure);
    ValueTask UpdateAsync(Expenditure expenditure);
    ValueTask DeleteAsync(Expenditure expenditure);
}