using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Infrastructure.Repositories;
using PersonalFinance.Infrastructure.Repositories.Interfaces;

namespace PersonalFinance.Application.DependencyInjection;

public static class RepositoryExtansion
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

        services.AddScoped(typeof(IExpendtureCategoryRepository), typeof(ExpendtureCategoryRepository));

        services.AddScoped(typeof(IExpendtureRepository), typeof(ExpendtureRepository));

        services.AddScoped(typeof(IRevenueCategoryRepository), typeof(RevenueCategoryRepository));

        services.AddScoped(typeof(IRevenueRepository), typeof(RevenueRepository));

        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

        services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            
        return services;
    }
}
