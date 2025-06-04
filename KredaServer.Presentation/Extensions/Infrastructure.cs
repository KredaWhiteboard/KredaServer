using System.Data;

using KredaServer.Domain;
using KredaServer.Infrastructure;

namespace KredaServer.Presentation.Extensions;

public static class ServiceCollectionExtensionsInfrastructure
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new List<string> { "Kubale", "Bereda" });
        services.AddNpgsqlDataSource(configuration["DATABASE_CONNECTION_STRING"]
            ?? throw new NoNullAllowedException("DATABASE_CONNECTION_STRING environment variable is invalid."));

        services.AddScoped<ITestRepository, PgTestRepository>();

        return services;
    }
}