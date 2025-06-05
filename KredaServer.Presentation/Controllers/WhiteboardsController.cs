using KredaServer.Application.Whiteboards;

using Microsoft.AspNetCore.Mvc;

namespace KredaServer.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class WhiteboardsController(InsertWhiteboard insertWhiteboard) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> InsertWhiteboard(CancellationToken cancellationToken)
    {
        return await insertWhiteboard.Execute(cancellationToken);
    }
}