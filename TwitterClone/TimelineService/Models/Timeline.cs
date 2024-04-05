using SharedModels;

namespace TimelineService.Models;

public class Timeline
{
    public string Id { get; set; }
    public int UserId { get; set; }
    public ICollection<Tweet> Tweets { get; set; }
}