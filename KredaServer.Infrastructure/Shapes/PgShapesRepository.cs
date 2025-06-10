using Dapper;
using Npgsql;

using KredaServer.Domain.Shapes;

namespace KredaServer.Infrastructure.Shapes;

public class PgShapesRepository(NpgsqlConnection connection) : IShapesRepository
{
    public async Task DeleteShape(Guid id, CancellationToken cancellationToken)
    {
        await connection.ExecuteAsync(new CommandDefinition(
            "DELETE * FROM shapes WHERE id = @Id;",
            new { Id = id },
            cancellationToken: cancellationToken
        ));
    }

    public async Task<Shape?> GetShapeById(Guid id, CancellationToken cancellationToken)
    {
        return await connection.QuerySingleOrDefaultAsync<Shape?>(new CommandDefinition(
            "SELECT * FROM shapes WHERE id = @Id;",
            new { Id = id },
            cancellationToken: cancellationToken
        ));
    }

    public async Task InsertShape(Shape shape, CancellationToken cancellationToken)
    {
        await connection.ExecuteAsync(new CommandDefinition(
            @"INSERT INTO shapes(id,whiteboard_id,brush_size,r,g,b,a)
            VALUES(@Id,@WhiteboardId,@BrushSize,@R,@G,@B,@A);",
            shape,
            cancellationToken: cancellationToken
        ));
    }
}