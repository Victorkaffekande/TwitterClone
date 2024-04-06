using SharedModels;


namespace TweetService;

public interface ITweetRepository
{
 public Task<List<Tweet>> GetTweets();

 public Task<Tweet> SaveTweet(Tweet tweet);
}