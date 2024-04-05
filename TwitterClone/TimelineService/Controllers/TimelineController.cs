namespace TimelineService.Controllers;

using Microsoft.AspNetCore.Mvc;
using DTO;
using Models;
using Service;



[ApiController]
[Route("[controller]")]
public class TimelineController : ControllerBase
{
    private readonly ITimelineDataService _timelineDataService;

    public TimelineController(ITimelineDataService timelineDataService)
    {
        _timelineDataService = timelineDataService;
    }
    
    [HttpGet]
    [Route("user/{userId}")]
    public async Task<ActionResult<TimelineResponseDto>> GetUserTimeline(int userId)
    {
        var result = await _timelineDataService.GetTimelineByUserId(userId);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult PostUserTimeline(Timeline timeline)
    {
        _timelineDataService.CreateTimeline(timeline);
        return Ok();
    }
    
}