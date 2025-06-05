namespace KredaServer.Domain.Whiteboards;

public interface IWhiteboardsRepository
{
    public Task<Whiteboard> GetWhiteboardById(Guid id, CancellationToken cancellationToken);
    public Task InsertWhiteboard(Whiteboard whiteboard, CancellationToken cancellationToken);
}