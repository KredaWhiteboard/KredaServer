using Dapper;

using KredaServer.Domain;
using KredaServer.Domain.Users;

using Npgsql;

namespace KredaServer.Infrastructure;

public class PgUsersRepository(NpgsqlConnection connection) : IUsersRepository
{

    public async Task<string[]> GetUsernames(CancellationToken cancellationToken)
    {
        var result = await connection.QueryAsync<string>("SELECT username FROM users;");
        return [.. result];
    }

    public async Task InsertUser(User user, CancellationToken cancellationToken)
    {
        await connection.ExecuteAsync(new CommandDefinition(
            "INSERT INTO users(id,username,created_at) VALUES(@Id,@Username,@CreatedAt)",
            user,
            cancellationToken:cancellationToken
        ));
    }
}