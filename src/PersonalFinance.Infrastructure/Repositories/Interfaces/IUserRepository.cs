using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    ValueTask<User> GetByIdAsync(long id);
    ValueTask<User> GetByEmailAsync(string email);
    ValueTask<IEnumerable<User>> GetAllAsync();
    ValueTask AddAsync(User user);
    ValueTask UpdateAsync(User user);
    ValueTask DeleteAsync(User user);
}