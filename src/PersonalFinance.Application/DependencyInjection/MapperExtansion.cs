using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Application.Mappers;

namespace PersonalFinance.Application.DependencyInjection;

public static class MapperExtansion
{
    public static IServiceCollection AddAutoMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}