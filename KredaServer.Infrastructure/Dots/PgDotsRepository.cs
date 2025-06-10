using Dapper;
using Npgsql;

using KredaServer.Domain.Dots;

namespace KredaServer.Infrastructure.Dots;

public class PgDotsRepository(NpgsqlConnection connection) : IDotsRepository
{
    public async Task<Dot[]> GetDotsByShapeId(Guid id, CancellationToken cancellationToken)
    {
        var results = await connection.QueryAsync<Dot>(new CommandDefinition(
            "SELECT x, y, order FROM dots WHERE shape_id = @Id ORDER BY order;",
            new { Id = id },
            cancellationToken: cancellationToken
        ));
        return [.. results];
    }

    public async Task InsertDots(Dot[] dots, CancellationToken cancellationToken)
    {
        var dp = new DynamicParameters();
        foreach (Dot dot in dots)
        {
            dp.Add("@ShapeId", dot.ShapeId);
            dp.Add("@X", dot.X);
            dp.Add("@Y", dot.Y);
            dp.Add("@Order", dot.Order);
        }
        await connection.ExecuteAsync(new CommandDefinition(
            "INSERT INTO dots(shape_id,x,y,order) VALUES(@ShapeId,@X,@Y,@Order);",
            dp,
            cancellationToken: cancellationToken
        ));
    }
}