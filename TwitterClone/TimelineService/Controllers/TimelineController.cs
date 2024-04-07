using Microsoft.AspNetCore.Mvc;
using TimelineService.DTO;
using TimelineService.Models;
using TimelineService.Service;

namespace TimelineService.Controllers;

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
    public async Task<ActionResult> PostUserTimeline(Timeline timeline)
    {
        await _timelineDataService.CreateTimeline(timeline);
        return Ok();
    }
    
}