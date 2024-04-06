using AdditionService;
using Microsoft.AspNetCore.Server.IIS.Core;
using SharedModels;


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

    public async Task<Tweet> HandleNewTweet(Tweet tweet)
    {
        var savedTweet = await SaveTweet(tweet);
        TransferTweet(savedTweet);

        return savedTweet;
    }
    
    public async Task<Tweet> SaveTweet(Tweet tweet)
    {
        return await _tweetRepository.SaveTweet(tweet);
    }

    public void TransferTweet(Tweet tweet)
    {
        _messageClient.send( tweet, "Tweet");
    }

    public async Task<List<Tweet>> GetTweets()
    {
        return await _tweetRepository.GetTweets();
    }
}