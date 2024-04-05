using SharedModels;

namespace TweetService.Core.Services;

public interface ITweetService
{
    public Tweet HandleNewTweet(Tweet tweet);

    public Tweet SaveTweet(Tweet tweet);

    public void TransferTweet(Tweet tweet);

    public List<Tweet> GetTweets();
    
}