using Microsoft.AspNetCore.Server.IIS.Core;
using TweetService.Models;

namespace TweetService.Core.Services;

public class TweetService : ITweetService
{

    private readonly ITweetRepository _tweetRepository;

    public TweetService(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
    }

    public Tweet HandleNewTweet(Tweet tweet)
    {
        
        TransferTweet(tweet);
        
        return SaveTweet(tweet);
    }
    
    public Tweet SaveTweet(Tweet tweet)
    {
        return _tweetRepository.SaveTweet(tweet);
    }

    //TODO Implement messaging
    public void TransferTweet(Tweet tweet)
    {
        throw new NotImplementedException();
    }

    public List<Tweet> GetTweets()
    {
        return _tweetRepository.GetTweets();
    }
}