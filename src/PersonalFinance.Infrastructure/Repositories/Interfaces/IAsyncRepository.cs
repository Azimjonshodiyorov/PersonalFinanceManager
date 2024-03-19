using System.Linq.Expressions;
using PersonalFinance.Domain.Entities.Common;

namespace PersonalFinance.Infrastructure.Repositories.Interfaces;

public interface IAsyncRepository<T> where T : AuditableBaseEntity<long>
{
    ValueTask<T> GetByIdAsync(long id);
    ValueTask<T> GetByIdAsNoTrackingAsync(long id);
    ValueTask<IEnumerable<T>> GetAllAsync();
    ValueTask<IEnumerable<T>> GetAllAsNoTracking();
    ValueTask AddAsync(T entity);
    ValueTask UpdateAsync(T entity);
    ValueTask DeleteAsync(T entity);

    ValueTask<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> filter = null,
        Expression<Func<T, object>> orderBy = null,
        Expression<Func<T, object>> include = null);
    
    ValueTask<IEnumerable<T>> FindByAsNoTrackingAsync(Expression<Func<T, bool>> filter = null,
        Expression<Func<T, object>> orderBy = null,
        Expression<Func<T, object>> include = null);

    ValueTask<IEnumerable<T>> ExecProcedureAsync(string procedure, List<string> parametrs);
}