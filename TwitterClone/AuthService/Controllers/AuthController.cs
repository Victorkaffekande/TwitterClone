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
    public ActionResult ValidateToken(string jwt)
    {
        try
        {
            return Ok(_tokenValidator.ValidateToken(jwt));
        }
        catch (Exception e)
        {
            return new UnauthorizedResult();
        }
    }
}