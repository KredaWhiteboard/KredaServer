namespace KredaServer.Domain.Shapes;

public record ShapeInsertData(
    Guid WhiteboardId,
    byte BrushSize,
    byte R,
    byte G,
    byte B,
    byte A,
    bool ShapeFlag
);