
using KredaServer.Domain.Shapes;

namespace KredaServer.Application.Shapes;

public class GetShapeById(IShapesRepository shapesRepository)
{
    public async Task<Shape> Execute(Guid id, CancellationToken cancellationToken)
    {
        return await shapesRepository.GetShapeById(id, cancellationToken);
    }
}