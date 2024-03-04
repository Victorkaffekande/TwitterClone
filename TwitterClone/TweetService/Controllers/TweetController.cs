using Microsoft.AspNetCore.Mvc;

namespace TweetService.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    
    [HttpGet]
    [Route("test")]
    public ActionResult test()
    {
        return Ok("hello from tweet service");
    }
}