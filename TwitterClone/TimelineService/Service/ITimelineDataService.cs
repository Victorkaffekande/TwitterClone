using TimelineService.DTO;
using TweetService.Models;

namespace TimelineService.Service;

public interface ITimelineDataService
{
    Task<TimelineResponseDto> GetTimelineByUserId(int id);
}