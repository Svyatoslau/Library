using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    public UserController() { }

    [HttpPost("login")]
    public async Task<ActionResult> LoginUserAsync()
    {
        return Ok();
    }

    [HttpPost("registration")]
    public async Task<ActionResult> RegistrUserAsync() 
    {
        return Ok();
    }
}
