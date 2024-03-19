using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Repositories.Interfaces;

public interface IUserRoleRepository
{
    ValueTask<UserRole> GetByIdAsync(long id);
    ValueTask<UserRole> GetByIdAsNoTrackingAsync(long id);
    ValueTask<IEnumerable<UserRole>> GetAllAsNoTrackingAsync();
    ValueTask AddAsync(UserRole userRole);
    ValueTask UpdateAsync(UserRole userRole);
    ValueTask DeleteAsync(UserRole userRole);
}