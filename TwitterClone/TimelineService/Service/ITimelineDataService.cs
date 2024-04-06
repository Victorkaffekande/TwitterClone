using SharedModels;
using TimelineService.DTO;
using TimelineService.Models;
using TweetService.Models;

namespace TimelineService.Service;

public interface ITimelineDataService
{
    Task<TimelineResponseDto> GetTimelineByUserId(int id);
    Task AddTweetToTimelines(Tweet tweet, List<int> userIds);
    Task CreateTimeline(Timeline timeline);
}