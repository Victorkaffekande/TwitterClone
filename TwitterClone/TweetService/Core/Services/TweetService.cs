using AdditionService;
using Microsoft.AspNetCore.Server.IIS.Core;
using TweetService.Models;

namespace TweetService.Core.Services;

public class TweetService : ITweetService
{

    private readonly ITweetRepository _tweetRepository;

    private readonly MessageClient _messageClient;
    
    public TweetService(ITweetRepository tweetRepository, MessageClient messageClient)
    {
        _tweetRepository = tweetRepository;
        _messageClient = messageClient;
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

    public void TransferTweet(Tweet tweet)
    {
        _messageClient.send( tweet, "Tweet");
    }

    public List<Tweet> GetTweets()
    {
        return _tweetRepository.GetTweets();
    }
}