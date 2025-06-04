using Dapper;

using KredaServer.Domain;

using Npgsql;

namespace KredaServer.Infrastructure;

public class PgTestRepository(NpgsqlConnection connection) : ITestRepository
{
    public async Task<Guid[]> GetIds(CancellationToken cancellationToken)
    {
        var result = await connection.QueryAsync<Guid>("SELECT id FROM test;");
        return [.. result];
    }
}