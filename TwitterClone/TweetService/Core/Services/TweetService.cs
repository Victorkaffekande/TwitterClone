using TweetService.Models;

namespace TweetService.Core.Services;

public class TweetService
{

    private readonly ITweetRepository _tweetRepository;

    public TweetService(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
    }

    public Tweet HandleNewTweet(Tweet tweet)
    {
        return SaveTweet(tweet);
    }
    
    
    public Tweet SaveTweet(Tweet tweet)
    {
        return _tweetRepository.SaveTweet(tweet);
    }

    public void TransferTweet(Tweet tweet)
    {
        throw new NotImplementedException();
    }
    
}