
using KredaServer.Domain.Shapes;

namespace KredaServer.Application.Shapes;

public class InsertShape(IShapesRepository shapesRepository)
{
    public async Task<Guid> Execute(ShapeInsertData insertData, CancellationToken cancellationToken)
    {
        var shape = new Shape(
            Guid.NewGuid(),
            insertData.WhiteboardId,
            insertData.BrushSize,
            insertData.R,
            insertData.G,
            insertData.B,
            insertData.A,
            insertData.ShapeFlag
        );
        await shapesRepository.InsertShape(shape, cancellationToken);
        return shape.Id;
    }
}