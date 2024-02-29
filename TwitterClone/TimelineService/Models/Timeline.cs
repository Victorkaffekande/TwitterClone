namespace TweetService.Models;

public class Timeline
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<Tweet> Tweets { get; set; }
}