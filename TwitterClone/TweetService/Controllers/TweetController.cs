using Microsoft.AspNetCore.Mvc;
using TweetService.Core.Services;
using TweetService.Models;

namespace TweetService.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    private readonly ITweetRepository _tweetRepository;
    private readonly ITweetService _tweetService;
    
    public TweetController(ITweetRepository tweetRepository, ITweetService tweetService)
    {
        _tweetRepository = tweetRepository;
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
        return Ok(_tweetRepository.GetTweets());
    }

    [HttpPost]
    [Route("PostTweet")]
    public ActionResult PostTweet(Tweet tweet)
    {
        return Ok(_tweetService.HandleNewTweet(tweet));
    }
    
}