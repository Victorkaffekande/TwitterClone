using EasyNetQ;
using TimelineService.Models;
using TimelineService.Service;

namespace TimelineService;

public class MessageHandler : BackgroundService
{
    private readonly ITimelineDataService _timelineDataService;
    
    public MessageHandler(ITimelineDataService timelineDataService)
    {
        _timelineDataService = timelineDataService;
    }
    
    private void HandleTweetMessage(Tweet tweet)
    {
        Console.WriteLine($"new tweet: {tweet}");
        var userIds = new List<int>();
        userIds.Add(1);
        userIds.Add(2);
        Console.WriteLine((tweet));
        _timelineDataService.AddTweetToTimelines(tweet, userIds);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Message handler is running...");

        var messageClient = new MessageClient(
            RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualHost=/;username=guest;password=guest")
        );
        
        messageClient.Listen<Tweet>(HandleTweetMessage, "Tweet");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
        Console.WriteLine("Message handler is stopping...");
    }
}