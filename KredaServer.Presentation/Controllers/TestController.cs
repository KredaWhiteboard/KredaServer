using KredaServer.Application;

using Microsoft.AspNetCore.Mvc;

namespace KredaServer.Presentation.Controllers;

//atrybuty, dekoratory
[ApiController]
[Route("[controller]")]
public class TestController(TestHandler testHandler) : ControllerBase
{
    [HttpGet]
    public async Task<Guid[]> Get(CancellationToken cancellationToken)
    {
        return await testHandler.Execute(cancellationToken);
    }

    [HttpGet("kubale")]
    public string GetKubale()
    {
        return "Dopytka";
    }

    [HttpGet("kubale/data")]
    public string GetKubaleData()
    {
        DateTime kolos = new DateTime(2025, 6, 1);
        return kolos.ToString("'Ujebiemy kolosa 'dd.MM' roku Pańskiego 'yyyy ");
    }
}
