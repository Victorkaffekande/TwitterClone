using Microsoft.AspNetCore.Mvc;

namespace TweetService.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    private readonly ITweetRepository _tweetRepository;

    public TweetController(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
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
    
}