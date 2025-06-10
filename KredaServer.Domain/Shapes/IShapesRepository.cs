namespace KredaServer.Domain.Shapes;

public interface IShapesRepository
{
    public Task InsertShape (Shape shape, CancellationToken cancellationToken);
    public Task DeleteShape(Guid id, CancellationToken cancellationToken);
    public Task<Shape?> GetShapeById(Guid id, CancellationToken cancellationToken);
}