using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers;

public class GatewayController : ControllerBase
{
    private static string authService = "auth-service";
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
        //var res = _client.Send(new HttpRequestMessage(HttpMethod.Get, "Auth/test"));
        var res = _client.Send(new HttpRequestMessage(HttpMethod.Get, "http://auth-service/Auth/test"));
        
        var result = res.Content.ReadAsStringAsync().Result;
        return Ok(result);
    }
}