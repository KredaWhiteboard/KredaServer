namespace KredaServer.Domain.Users;

public record User(
    Guid Id,
    string Username,
    Guid WhiteboardId,
    DateTimeOffset CreatedAt
);