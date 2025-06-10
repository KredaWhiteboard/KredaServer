namespace KredaServer.Domain.Dots;

public record Dot(
    Guid ShapeId,
    int X,
    int Y,
    int Order
);