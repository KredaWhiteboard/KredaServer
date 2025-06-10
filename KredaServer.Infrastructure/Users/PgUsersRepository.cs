using Dapper;
using Npgsql;

using KredaServer.Domain.Users;

namespace KredaServer.Infrastructure.Users;

public class PgUsersRepository(NpgsqlConnection connection) : IUsersRepository
{

    public async Task<string[]> GetUsernames(CancellationToken cancellationToken)
    {
        var result = await connection.QueryAsync<string>("SELECT username FROM users;", cancellationToken);
        return [.. result];
    }

    public async Task<User[]> GetUsersByWhiteboardId(Guid id, CancellationToken cancellationToken)
    {
        var result = await connection.QueryAsync<User>(new CommandDefinition(
            "SELECT * FROM users WHERE whiteboard_id = @Id;",
            new
            {
                Id = id
            },
            cancellationToken: cancellationToken
        ));

        return [.. result];
    }

    public async Task InsertUser(User user, CancellationToken cancellationToken)
    {
        await connection.ExecuteAsync(new CommandDefinition(
            @"INSERT INTO users(id, username, whiteboard_id, created_at) 
            VALUES(@Id, @Username, @WhiteboardId, @CreatedAt)",
            user,
            cancellationToken: cancellationToken
        ));
    }
}