namespace KredaServer.Domain;

public interface ITestRepository
{
    public Task<Guid[]> GetIds(CancellationToken cancellationToken);
}