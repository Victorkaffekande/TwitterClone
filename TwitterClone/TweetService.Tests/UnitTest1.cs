using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedModels;
using TweetService;
using TweetService.Controllers;

public class UnitTest1
{
    [Fact]
    public void GetTweets_service()
    {
        //Arrange
        var mockRepo = new Mock<ITweetRepository>();
        mockRepo.Setup(r => r.GetTweets()).Returns(
            Task.FromResult(new List<Tweet>()
            {
                new()
                {
                    AuthorHandle = "Young killa",
                    Body = "i just got my new bike today",
                    Id = 1,
                    Timestamp = DateTime.Now,
                    AuthorName = "Karsten",
                    UserId = 1,
                },
                new()
                {
                    AuthorHandle = "SlimDingus",
                    Body = "i just got my new bike today",
                    Id = 2,
                    Timestamp = DateTime.Now,
                    AuthorName = "Triss",
                    UserId = 2,
                }
            }));
        var mockClient = new Mock<MessageClient>();

        var service = new TweetService.Core.Services.TweetService(mockRepo.Object, mockClient.Object);

        //Act
        var res = service.GetTweets();

        //Assert
        Assert.True(res.Result.Count == 2);
    }


    [Fact]
    public void NewTweet_Service()
    {
        //Arrange
        var tweet = new Tweet
        {
            AuthorHandle = "SlimDingus",
            Body = "i just got my new bike today",
            Timestamp = DateTime.Now,
            AuthorName = "Triss",
            UserId = 2,
        };
        var resultTweet = new Tweet
        {
            Id = 1,
            AuthorHandle = "SlimDingus",
            Body = "i just got my new bike today",
            Timestamp = DateTime.Now,
            AuthorName = "Triss",
            UserId = 2,
        };
        var mockRepo = new Mock<ITweetRepository>();
        mockRepo.Setup(r => r.SaveTweet(tweet)).Returns(Task.FromResult(resultTweet));
        var mockClient = new Mock<MessageClient>();
        mockClient.Setup(x => x.Send(tweet, "tweet"));

        var service = new TweetService.Core.Services.TweetService(mockRepo.Object, mockClient.Object);

        //act
        var res = service.HandleNewTweet(tweet);

        //assert
        Assert.True(res.Result == resultTweet);
        mockClient.Verify(client => client.Send(tweet, "tweet"), Times.AtMostOnce);
    }


    [Fact]
    public void NewTweet_controller()
    {
        //Arrange
        var mockService = new Mock<TweetService.Core.Services.ITweetService>();
        var controller = new TweetController(mockService.Object);

        //act
        var result = controller.GetTweets();

        //assert
        mockService.Verify(x => x.GetTweets(), Times.AtMostOnce);
    }

    [Fact]
    public async Task NewTweet_controller2()
    {
        //Arrange
        var tweet = new Tweet()
        {
            AuthorHandle = "Young killa",
            Body = "i just got my new bike today",
            Timestamp = DateTime.Now,
            AuthorName = "Karsten",
            UserId = 1,
        };
        var expectedTweet = new Tweet()
        {
            Id = 1,
            AuthorHandle = "Young killa",
            Body = "i just got my new bike today",
            Timestamp = DateTime.Now,
            AuthorName = "Karsten",
            UserId = 1,
        };
        var mockService = new Mock<TweetService.Core.Services.ITweetService>();
        mockService.Setup(x => x.HandleNewTweet(tweet)).ReturnsAsync(expectedTweet);
        var controller = new TweetController(mockService.Object);


        //act
        var actionResult = await controller.PostTweet(tweet);

        //assert
        var result = actionResult.Result;
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Tweet>(okResult.Value);
        Assert.Equal(expectedTweet, returnValue);

        mockService.Verify(x => x.HandleNewTweet(tweet), Times.AtMostOnce);
    }
    
}