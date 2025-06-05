using KredaServer.Application.Users;

using Microsoft.AspNetCore.Mvc;

namespace KredaServer.Presentation.Controllers;

//atrybuty, dekoratory
[ApiController]
[Route("[controller]")]
public class UsersController(GetUsernames getUsernames, InsertUser insertUser) : ControllerBase
{
    [HttpGet]
    public async Task<string[]> GetUsers(CancellationToken cancellationToken)
    {
        return await getUsernames.Execute(cancellationToken);
    }

    [HttpPost("/users/register")]
    public async Task<Guid> InsertUser([FromBody] string username, CancellationToken cancellationToken)
    {
        return await insertUser.Execute(username, cancellationToken);
    }
}