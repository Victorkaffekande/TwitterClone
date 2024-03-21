using TimelineService.Models;

namespace TimelineService.Repository;

public interface ITimelineRepository
{
    Task<Timeline> GetTimelineByUserId(int id);
    void AddTweetToTimelines(Tweet tweet, List<int> userIds);

}