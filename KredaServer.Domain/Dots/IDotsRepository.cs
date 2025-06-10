namespace KredaServer.Domain.Dots;

public interface IDotsRepository
{
    public Task InsertDots(Dot[] dots, CancellationToken cancellationToken);
    public Task<Dot[]> GetDotsByShapeId(Guid id, CancellationToken cancellationToken);
}