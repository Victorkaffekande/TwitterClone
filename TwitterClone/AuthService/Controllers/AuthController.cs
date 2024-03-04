using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet]
    [Route("test")]
    public ActionResult TestAuth()
    {
        return Ok("Hello from Auth");
    }
}