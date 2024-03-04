﻿using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers;

public class GatewayController : ControllerBase
{
    private static string authService = "auth-service";
    private static string timelineService = "timeline-service";
    private static string tweetService = "tweet-service";
    private HttpClient _client = new();

    [HttpGet]
    [Route("test")]
    public ActionResult test()
    {
        return Ok("hello from client api");
    }

    [HttpGet]
    [Route("AuthTest")]
    public ActionResult AuthTest()
    {
        var res = _client.Send(new HttpRequestMessage(HttpMethod.Get, $"http://{authService}/auth/test"));
        
        var result = res.Content.ReadAsStringAsync().Result;
        return Ok(result);
    }
    
    [HttpGet]
    [Route("TimelineTest")]
    public ActionResult TimelineTest()
    {
        var res = _client.Send(new HttpRequestMessage(HttpMethod.Get, $"http://{timelineService}/timeline/test"));
        
        var result = res.Content.ReadAsStringAsync().Result;
        return Ok(result);
    }
    
    [HttpGet]
    [Route("TweetTest")]
    public ActionResult TweetTest()
    {
        var res = _client.Send(new HttpRequestMessage(HttpMethod.Get, $"http://{tweetService}/tweet/test"));
        
        var result = res.Content.ReadAsStringAsync().Result;
        return Ok(result);
    }
}