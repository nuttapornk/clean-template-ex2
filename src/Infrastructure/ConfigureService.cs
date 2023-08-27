using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection service)
    {
        return service;
    }
}
