using KredaServer.Domain.Users;

namespace KredaServer.Application.Users;

public class GetUsernames(IUsersRepository usersRepository)
{
    public async Task<string[]> Execute(CancellationToken cancellationToken)
    {
        return await usersRepository.GetUsernames(cancellationToken);
    }
}