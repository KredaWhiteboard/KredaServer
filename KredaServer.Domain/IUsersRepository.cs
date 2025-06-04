using KredaServer.Domain.Users;

namespace KredaServer.Domain;

public interface IUsersRepository
{
    public Task<string[]> GetUsernames(CancellationToken cancellationToken);
    public Task InsertUser(User user, CancellationToken cancellationToken);
}