using Microsoft.AspNetCore.Mvc;
using SharedModels;
using TweetService.Core.Services;

namespace TweetService.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    private readonly ITweetService _tweetService;
    public TweetController( ITweetService tweetService)
    {
        _tweetService = tweetService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Tweet>>> GetTweets()
    {
        return Ok(await _tweetService.GetTweets());
    }

    [HttpPost]
    public async Task<ActionResult<Tweet>> PostTweet(Tweet tweet)
    {
        return Ok(await _tweetService.HandleNewTweet(tweet));
    }
    
}