using KredaServer.Domain.Dots;

namespace KredaServer.Application.Dots;

public class GetDotsByShapeId(IDotsRepository dotsRepository)
{
    public async Task<Dot[]> Execute(Guid id, CancellationToken cancellationToken)
    {
        return await dotsRepository.GetDotsByShapeId(id, cancellationToken);
    }
}