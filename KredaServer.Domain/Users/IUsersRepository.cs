namespace KredaServer.Domain.Users;

public interface IUsersRepository
{
    public Task<string[]> GetUsernames(CancellationToken cancellationToken);
    public Task<User[]> GetUsersByWhiteboardId(Guid id, CancellationToken cancellationToken);
    public Task InsertUser(User user, CancellationToken cancellationToken);
}