namespace TimelineService.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TimelineController : ControllerBase
{
    [HttpGet]
    [Route("test")]
    public ActionResult test()
    {
        return Ok("hello from timeline service");
    }
}