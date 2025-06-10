
using KredaServer.Domain.Shapes;

namespace KredaServer.Application.Shapes;

public class DeleteShape(IShapesRepository shapesRepository)
{
    public async Task Execute(Guid id, CancellationToken cancellationToken)
    {
        await shapesRepository.DeleteShape(id, cancellationToken);
    }
}