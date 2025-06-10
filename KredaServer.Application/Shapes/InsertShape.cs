
using KredaServer.Domain.Shapes;

namespace KredaServer.Application.Shapes;

public class InsertShape(IShapesRepository shapesRepository)
{
    public async Task Execute(Shape shape, CancellationToken cancellationToken)
    {
        await shapesRepository.InsertShape(shape, cancellationToken);
    }
}