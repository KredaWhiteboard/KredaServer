using Microsoft.AspNetCore.Mvc;

namespace KredaServer.Presentation.Controllers;

//atrybuty, dekoratory
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Endpoint is working";
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
