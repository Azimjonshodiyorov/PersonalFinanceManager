using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Entities.Common;
using PersonalFinance.Infrastructure.Context;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Infrastructure.Repositories;

public class AsyncRepository<T> : IAsyncRepository<T> where T : AuditableBaseEntity<long> 
{
    private readonly AppDbContext _dbContext;

    public AsyncRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask<T> GetByIdAsync(long id)
    {
        return await this._dbContext.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<T> GetByIdAsNoTrackingAsync(long id)
    {
        return await this._dbContext.Set<T>()
            .AsTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<IEnumerable<T>> GetAllAsync()
    {
        return await this._dbContext.Set<T>().ToListAsync();
    }

    public async ValueTask<IEnumerable<T>> GetAllAsNoTracking()
    {
        return await this._dbContext.Set<T>().AsTracking().ToListAsync();
    }

    public async ValueTask AddAsync(T entity)
    {
        await this._dbContext.Set<T>().AddAsync(entity);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(T entity)
    {
         this._dbContext.Set<T>().Update(entity);
         await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(T entity)
    {
        this._dbContext.Remove(entity);
        await this._dbContext.SaveChangesAsync();
    }

    public async ValueTask<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> filter = null, 
        Expression<Func<T, object>> orderBy = null, 
        Expression<Func<T, object>> include = null)
    {
        IQueryable<T> query = this._dbContext.Set<T>();
        if (filter != null)
            query.Where(filter);
        if (orderBy != null)
            query.OrderBy(orderBy);
        if (include != null)
            query.Include(include);

        return await query.ToListAsync();
    }

    public async ValueTask<IEnumerable<T>> FindByAsNoTrackingAsync(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, Expression<Func<T, object>> include = null)
    {
        IQueryable<T> query = this._dbContext.Set<T>();

        if (filter != null)
            query.Where(filter);
        if (orderBy != null)
            query.OrderBy(orderBy);
        if (include != null)
            query.Include(include);
        return await query.AsTracking().ToListAsync();
    }

    public async ValueTask<IEnumerable<T>> ExecProcedureAsync(string procedure, List<string> parametrs)
    {
        if (procedure == null)
            return await this._dbContext.Set<T>().FromSqlInterpolated($"call {procedure}").ToListAsync();
        var queryString = $"call {procedure} ({string.Join(", ",procedure)})";

        var query = this._dbContext.Set<T>().FromSqlRaw(queryString);

        return await query.ToListAsync();
    }
}