using Dapper;
using Npgsql;

using KredaServer.Domain.Whiteboards;

namespace KredaServer.Infrastructure.Whiteboards;

public class PgWhiteboardsRepository(NpgsqlConnection connection) : IWhiteboardsRepository
{
    public async Task<Whiteboard> GetWhiteboardById(Guid id, CancellationToken cancellationToken)
    {
        return await connection.QuerySingleAsync<Whiteboard>(new CommandDefinition(
            "SELECT * FROM whiteboards WHERE id = @Id;",
            new { Id = id },
            cancellationToken: cancellationToken
        ));
    }

    public async Task InsertWhiteboard(Whiteboard whiteboard, CancellationToken cancellationToken)
    {
        await connection.ExecuteAsync(new CommandDefinition(
            "INSERT INTO whiteboards(id, created_at) VALUES(@Id, @CreatedAt);",
            whiteboard,
            cancellationToken: cancellationToken
        ));
    }
}