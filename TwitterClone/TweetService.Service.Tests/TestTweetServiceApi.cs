using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NJsonSchema.Extensions;
using SharedModels;
using TweetService.Controllers;

namespace TweetService.Service.Tests;
public class TestTweetServiceApi
{
    [Fact]
    public async Task TestPost_PostTweet()
    {
        // Arrange
        var contextMock = new Mock<ITweetContext>(); 
        var tweetDbSetMock = new Mock<DbSet<Tweet>>();
        contextMock.Setup(c => c.Tweets).Returns(tweetDbSetMock.Object); 
        contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1); 
        var messageClientMock = new Mock<IMessageClient>();
        var repo = new TweetRepository(contextMock.Object);
        var service = new Core.Services.TweetService(repo, messageClientMock.Object);
        var controller = new TweetController(service);
        var tweet = new Tweet
        {
            Id = 5,
            UserId = 2,
            AuthorHandle = "TestPerson",
            AuthorName = "TestPerson",
            Body = "TestTweet",
            Timestamp = DateTime.Now,
        };
        
        // Act
        
        var result = await controller.PostTweet(tweet);
      
        // Assert
        Assert.NotNull(result);
        
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedTweet = Assert.IsType<Tweet>(okResult.Value);
        
        tweetDbSetMock.Verify(db => db.AddAsync(It.IsAny<Tweet>(), CancellationToken.None), Times.Once);
        contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        
        Assert.NotNull(returnedTweet);

        messageClientMock.Verify(m => m.Send(It.Is<Tweet>(t => t.Equals(tweet)), "Tweet"), Times.Once);
    }
}