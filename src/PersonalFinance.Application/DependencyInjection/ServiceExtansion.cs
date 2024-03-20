using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Application.Interfaces;
using PersonalFinance.Application.Services;

namespace PersonalFinance.Application.DependencyInjection;

public static class ServiceExtansion
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IUserRoleService, UserRoleService>();

        services.AddScoped<IRevenueService, RevenueService>();

        services.AddScoped<IRevenueCategoryService, RevenueCategoryService>();

        services.AddScoped<IExpenditureService, ExpenditureService>();

        services.AddScoped<IExpenditureCategoryService, ExpenditureCategoryService>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}