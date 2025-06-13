namespace KredaServer.Presentation.Dtos;

public enum ToolType
{
    Pencil,
    Rubber,
}

public record UserActionDto(
    int X,
    int Y,
    ToolType? Tool,
    int? Order,
    byte? BrushSize,
    byte? R,
    byte? G,
    byte? B,
    byte? A
);