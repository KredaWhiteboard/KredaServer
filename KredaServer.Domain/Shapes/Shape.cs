namespace KredaServer.Domain.Shapes;

public record Shape(
    Guid Id,    //ShapeId
    Guid WhiteboardId,
    byte BrushSize,
    byte R,
    byte G,
    byte B,
    byte A
    
);