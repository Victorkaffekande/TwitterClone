using EasyNetQ;

namespace AdditionService;

public class MessageClient
{
    private readonly IBus _bus;

    public MessageClient(IBus bus)
    {
        _bus = bus;
    }

    public void send<T>(T message, string topic)
    {
        _bus.PubSub.Publish(message, topic);
    }
}