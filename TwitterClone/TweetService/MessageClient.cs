using EasyNetQ;

namespace TweetService;

public class MessageClient : IMessageClient
{
    private readonly IBus _bus;

    public MessageClient(IBus bus)
    {
        _bus = bus;
    }

    
    public void Send<T>(T message, string topic)
    {
        _bus.PubSub.PublishAsync(message, topic);
    }
}