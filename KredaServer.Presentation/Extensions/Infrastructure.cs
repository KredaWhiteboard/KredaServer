namespace KredaServer.Presentation.Extensions;

public static class ServiceCollectionExtensionsInfrastructure
{
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new List<string> { "Kubale", "Bereda" });
        return services;
    }
}