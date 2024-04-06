using AuthenticationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthenticationController(JwtTokenService jwtTokenService )
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost]
    public IActionResult Login()
    {
        var token = _jwtTokenService.CreateToken();
        return Ok(token);
    }
}