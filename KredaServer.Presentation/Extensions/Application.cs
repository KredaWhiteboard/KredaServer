using KredaServer.Application;

namespace KredaServer.Presentation.Extensions;

public static class ServiceCollectionExtensionsApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetUsers>();
        return services;
    }
}