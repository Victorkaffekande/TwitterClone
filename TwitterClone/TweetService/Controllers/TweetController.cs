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
    [Route("test")]
    public ActionResult test()
    {
        return Ok("hello from tweet service");
    }
    [HttpGet]
    [Route("tweet")]
    public ActionResult GetTweets()
    {
        return Ok(_tweetService.GetTweets());
    }

    [HttpPost]
    [Route("PostTweet")]
    public ActionResult PostTweet(Tweet tweet)
    {
        return Ok(_tweetService.HandleNewTweet(tweet));
    }
    
}