using Microsoft.AspNetCore.Mvc;

namespace KredaServer.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Endpoint is working";
    }
}
