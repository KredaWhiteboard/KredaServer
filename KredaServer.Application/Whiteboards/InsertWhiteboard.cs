using KredaServer.Domain.Users;
using KredaServer.Domain.Whiteboards;

namespace KredaServer.Application.Whiteboards;

public class InsertWhiteboard(IWhiteboardsRepository whiteboardsRepository)
{
    public async Task<Guid> Execute(CancellationToken cancellationToken)
    {
        var whiteboard = new Whiteboard(Guid.NewGuid(), DateTimeOffset.UtcNow);
        await whiteboardsRepository.InsertWhiteboard(whiteboard, cancellationToken);
        return whiteboard.Id;
    }
}