using Dapper;
using Npgsql;

using KredaServer.Domain.Whiteboards;

namespace KredaServer.Infrastructure.Whiteboards;

public class PgWhiteboardsRepository(NpgsqlConnection connection) : IWhiteboardsRepository
{
    public async Task<Whiteboard?> GetWhiteboardById(Guid id, CancellationToken cancellationToken)
    {
        var result = await connection.QueryFirstOrDefaultAsync(new CommandDefinition(
            "SELECT * FROM whiteboards WHERE id = @Id;",
            new { Id = id },
            cancellationToken: cancellationToken
        ));

        return result is not null ? MapToWhiteboard(result) : null;
    }

    public async Task InsertWhiteboard(Whiteboard whiteboard, CancellationToken cancellationToken)
    {
        await connection.ExecuteAsync(new CommandDefinition(
            "INSERT INTO whiteboards(id, created_at) VALUES(@Id, @CreatedAt);",
            whiteboard,
            cancellationToken: cancellationToken
        ));
    }

    private static Whiteboard MapToWhiteboard(dynamic data)
    {
        return new Whiteboard(
            Id: data.id,
            CreatedAt: data.created_at
        );
    }
}