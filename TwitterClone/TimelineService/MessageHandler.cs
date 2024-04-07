using EasyNetQ;
using SharedModels;
using TimelineService.Service;

namespace TimelineService;

public class MessageHandler : BackgroundService
{
    private readonly ITimelineDataService _timelineDataService;
    private MessageClient _messageClient;
    
    public MessageHandler(ITimelineDataService timelineDataService, MessageClient messageClient)
    {
        _timelineDataService = timelineDataService;
        _messageClient = messageClient;
    }

    private List<int> GetFollowers()
    {
        return new List<int>
        {
            1, 2, 3, 4
        };
    }

    private async void HandleTweetMessage(Tweet tweet)
    {
        Console.WriteLine($"new tweet: {tweet}");
        //For a real application, we would have a smarter way of getting the userIds of the users whose timeline we want to add the tweet to
        var userIds = GetFollowers();
        await _timelineDataService.AddTweetToTimelines(tweet, userIds);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Message handler is running...");
        
        _messageClient.Listen<Tweet>(HandleTweetMessage, "Tweet");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
        Console.WriteLine("Message handler is stopping...");
    }
}