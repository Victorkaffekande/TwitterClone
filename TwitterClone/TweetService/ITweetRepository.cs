using TweetService.Models;

namespace TweetService;

public interface ITweetRepository
{
 public List<Tweet> GetTweets();

 public Tweet SaveTweet();
}