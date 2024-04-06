using SharedModels;

namespace TweetService.Core.Services;

public interface ITweetService
{
    public Task<Tweet> HandleNewTweet(Tweet tweet);

    public Task<Tweet> SaveTweet(Tweet tweet);

    public void TransferTweet(Tweet tweet);

    public Task<List<Tweet>> GetTweets();
    
}