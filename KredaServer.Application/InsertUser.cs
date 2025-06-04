using KredaServer.Domain;
using KredaServer.Domain.Users;

namespace KredaServer.Application;

public class InsertUser(IUsersRepository usersRepository)
{
    public async Task<Guid> Execute(string username, CancellationToken cancellationToken)
    {
        if (username.Length > 100 || string.IsNullOrWhiteSpace(username))
        {
            throw new Exception("username too long or empty");
        }
        var user = new User(Guid.NewGuid(), username, DateTime.UtcNow);
        await usersRepository.InsertUser(user, cancellationToken);
        return user.Id;
    }
}