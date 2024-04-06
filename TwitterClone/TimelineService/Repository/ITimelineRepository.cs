using SharedModels;
using TimelineService.Models;

namespace TimelineService.Repository;

public interface ITimelineRepository
{
    Task<Timeline> GetTimelineByUserId(int id);
    Task AddTweetToTimelines(Tweet tweet, List<int> userIds);
    Task CreateTimeline(Timeline timeline);

}