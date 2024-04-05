using SharedModels;
using TimelineService.DTO;
using TimelineService.Models;
using TweetService.Models;

namespace TimelineService.Service;

public interface ITimelineDataService
{
    Task<TimelineResponseDto> GetTimelineByUserId(int id);
    void AddTweetToTimelines(Tweet tweet, List<int> userIds);
    void CreateTimeline(Timeline timeline);
}