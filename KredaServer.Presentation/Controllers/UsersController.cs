using KredaServer.Application;

using Microsoft.AspNetCore.Mvc;

namespace KredaServer.Presentation.Controllers;

//atrybuty, dekoratory
[ApiController]
[Route("[controller]")]
public class UsersController(GetUsers getUsers) : ControllerBase
{
    [HttpGet]
    public string[] GetUsers()
    {
        return getUsers.Execute();
    }

}
