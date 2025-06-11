using KredaServer.Domain.Whiteboards;

namespace KredaServer.Application.Whiteboards;

public class GetWhiteboardById(IWhiteboardsRepository whiteboardsRepository)
{
    public async Task<Whiteboard> Execute(Guid id, CancellationToken cancellationToken)
    {
        return await whiteboardsRepository.GetWhiteboardById(id, cancellationToken)
            ?? throw new Exception($"Whiteboard with id {id} not found.");
    }
}