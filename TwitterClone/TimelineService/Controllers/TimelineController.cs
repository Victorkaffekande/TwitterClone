using Microsoft.AspNetCore.Mvc;
using TimelineService.DTO;
using TimelineService.Repository;
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
    [Route("user")]
    public async Task<ActionResult<TimelineResponseDto>> GetUserTimeline(int userId)
    {
        var result = await _timelineDataService.GetTimelineByUserId(userId);
        return Ok(result);
    }

}