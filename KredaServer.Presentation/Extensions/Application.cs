using KredaServer.Application.Users;
using KredaServer.Application.Whiteboards;

namespace KredaServer.Presentation.Extensions;

public static class ServiceCollectionExtensionsApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetUsernames>();
        services.AddScoped<InsertUser>();

        services.AddScoped<GetWhiteboardById>();
        services.AddScoped<InsertWhiteboard>();

        return services;
    }
}