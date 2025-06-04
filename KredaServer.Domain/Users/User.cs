namespace KredaServer.Domain.Users;

public record User (Guid Id, string Username, DateTimeOffset CreatedAt);