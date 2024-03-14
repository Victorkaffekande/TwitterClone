using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenValidator _tokenValidator;

    public AuthController(ITokenValidator tokenValidator)
    {
        _tokenValidator = tokenValidator;
    }

    [HttpGet]
    [Route("test")]
    public ActionResult TestAuth()
    {
        return Ok("Hello from Auth");
    }

    [HttpPost]
    [Route("Validate")]
    public ActionResult ValidateToken(TokenDto tokenDto)
    {
        try
        {
            return Ok(_tokenValidator.ValidateToken(tokenDto.Jwt));
        }
        catch (Exception e)
        {
            return new UnauthorizedResult();
        }
    }
}