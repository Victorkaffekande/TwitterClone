using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedModels;
using TimelineService.Controllers;
using TimelineService.DTO;
using TimelineService.Models;
using TimelineService.Repository;
using TimelineService.Service;

namespace TimelineService.Test;

public class TimelineControllerTest
{
    [Fact]
    public async void GetUserTimelineTest()
    {
        var serviceMock = new Mock<ITimelineDataService>();
        var mockResult = new TimelineResponseDto();
        var userId = 1;
        serviceMock.Setup(service => service.GetTimelineByUserId(It.Is<int>(id => id == userId)))
            .ReturnsAsync(mockResult)
            .Verifiable();
        var controller = new TimelineController(serviceMock.Object);

        var res = await controller.GetUserTimeline(userId);
        
        //returns Ok result
        var okResult = Assert.IsType<OkObjectResult>(res.Result);
        //result value is TimelineResponseDto
        var returnValue = Assert.IsType<TimelineResponseDto>(okResult.Value);
        //correct value is returned
        Assert.Equal(mockResult, returnValue);  
        //service.GetTimelineByUserId is called once with correct parameters
        serviceMock.Verify(service => service.GetTimelineByUserId(It.Is<int>(id => id == userId)), Times.Once);  
    }
    
    [Fact]
    public async void PostUserTimelineTest()
    {
        var serviceMock = new Mock<ITimelineDataService>();
        var timeline = new Timeline();
        
        serviceMock.Setup(service => service.CreateTimeline(It.Is<Timeline>(t => t == timeline)))
            .Returns(Task.CompletedTask)
            .Verifiable();
        
        var controller = new TimelineController(serviceMock.Object);

        var res = await controller.PostUserTimeline(timeline);
        
        //returns Ok result
        var okResult = Assert.IsType<OkResult>(res);
        //service.GetTimelineByUserId is called once with correct parameters
        serviceMock.Verify(service => service.CreateTimeline(It.Is<Timeline>(t => t == timeline)), Times.Once);  
    }
}

public class TimelineDataServiceTest
{
    [Fact]  
    public async Task GetUserTimelineTest()  
    {  
        var repoMock = new Mock<ITimelineRepository>();  
        var mapperMock = new Mock<IMapper>();  
        var mockResult = new Timeline();  
          
        var timelineResponse = new TimelineResponseDto();  
        var userId = 1;  
          
        repoMock.Setup(repo => repo.GetTimelineByUserId(It.Is<int>(id => id == userId)))  
            .ReturnsAsync(mockResult)  
            .Verifiable();  
        mapperMock.Setup(mapper => mapper.Map<TimelineResponseDto>(It.Is<Timeline>(t => t == mockResult)))  
            .Returns(timelineResponse)  
            .Verifiable();  
          
        var service = new TimelineDataService(repoMock.Object, mapperMock.Object);  
  
        var res = await service.GetTimelineByUserId(userId);  
          
        //returns timeline result  
        var returnValue = Assert.IsType<TimelineResponseDto>(res);  
        //correct value is returned  
        Assert.Equal(timelineResponse, returnValue);    
        //service.GetTimelineByUserId is called once with correct parameters  
        repoMock.Verify(repo => repo.GetTimelineByUserId(It.Is<int>(id => id == userId)), Times.Once);    
    }  
    
    [Fact]  
    public async Task AddTweetToTimelinesTest()  
    {  
        // Arrange  
        var repoMock = new Mock<ITimelineRepository>();  
        var tweet = new Tweet(); 
        var userIds = new List<int> {1, 2, 3};
  
        repoMock.Setup(repo => repo.AddTweetToTimelines(It.Is<Tweet>(t => t == tweet), It.Is<List<int>>(list => list.SequenceEqual(userIds))))  
            .Returns(Task.CompletedTask)  
            .Verifiable();  
          
        var service = new TimelineDataService(repoMock.Object, null);  
  
        // Act  
        await service.AddTweetToTimelines(tweet, userIds);  
  
        // Assert  
        repoMock.Verify(repo => repo.AddTweetToTimelines(It.Is<Tweet>(t => t == tweet), It.Is<List<int>>(list => list.SequenceEqual(userIds))), Times.Once);    
    }  
  
    [Fact]  
    public async Task CreateTimelineTest()  
    {  
        // Arrange  
        var repoMock = new Mock<ITimelineRepository>();  
        var timeline = new Timeline(); 
  
        repoMock.Setup(repo => repo.CreateTimeline(It.Is<Timeline>(t => t == timeline)))  
            .Returns(Task.CompletedTask)  
            .Verifiable();  
          
        var service = new TimelineDataService(repoMock.Object, null);  
  
        // Act  
        await service.CreateTimeline(timeline);  
  
        // Assert  
        repoMock.Verify(repo => repo.CreateTimeline(It.Is<Timeline>(t => t == timeline)), Times.Once);    
    }
}