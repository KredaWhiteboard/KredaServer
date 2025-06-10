using System.Data;

using KredaServer.Domain.Dots;
using KredaServer.Domain.Shapes;
using KredaServer.Domain.Users;
using KredaServer.Domain.Whiteboards;
using KredaServer.Infrastructure.Dots;
using KredaServer.Infrastructure.Shapes;
using KredaServer.Infrastructure.Users;
using KredaServer.Infrastructure.Whiteboards;

namespace KredaServer.Presentation.Extensions;

public static class ServiceCollectionExtensionsInfrastructure
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsqlDataSource(configuration["DATABASE_CONNECTION_STRING"]
            ?? throw new NoNullAllowedException("DATABASE_CONNECTION_STRING environment variable is invalid."));

        services.AddScoped<IUsersRepository, PgUsersRepository>();
        services.AddScoped<IWhiteboardsRepository, PgWhiteboardsRepository>();
        services.AddScoped<IDotsRepository, PgDotsRepository>();
        services.AddScoped<IShapesRepository, PgShapesRepository>();
        return services;
    }
}