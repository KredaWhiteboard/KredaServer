using System.Collections.Concurrent;

using KredaServer.Presentation.Utils;

namespace KredaServer.Presentation.Extensions;

public static class ServiceCollectionExtensionsPresentation
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowClient", policy =>
            {
                policy.WithOrigins("http://localhost:8080", "null")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        services.AddControllers();
        services.AddOpenApi();

        services.AddSignalR(o =>
        {
            o.EnableDetailedErrors = true;
        });

        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

        services.AddSingleton(provider => new ConcurrentDictionary<string, ConnectionContext>());

        return services;
    }
}