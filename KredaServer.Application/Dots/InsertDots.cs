using KredaServer.Domain.Dots;

namespace KredaServer.Application.Dots;

public class InsertDots(IDotsRepository dotsRepository)
{
    public async Task Execute(Dot[] dots, CancellationToken cancellationToken)
    {
        await dotsRepository.InsertDots(dots, cancellationToken);
    }
}