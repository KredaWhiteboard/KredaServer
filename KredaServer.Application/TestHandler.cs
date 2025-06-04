using KredaServer.Domain;

namespace KredaServer.Application;

public class TestHandler(ITestRepository testRepository)
{
    public async Task<Guid[]> Execute(CancellationToken cancellationToken)
    {
        return await testRepository.GetIds(cancellationToken);
    }
}