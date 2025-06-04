using KredaServer.Domain;

namespace KredaServer.Application;

public class GetUsernames(IUsersRepository usersRepository)
{
    public async Task<string[]> Execute(CancellationToken cancellationToken)
    {
        return await usersRepository.GetUsernames(cancellationToken);
    }
}