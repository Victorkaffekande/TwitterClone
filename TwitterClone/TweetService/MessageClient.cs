﻿using EasyNetQ;

namespace TweetService;

public class MessageClient
{
    private readonly IBus _bus;

    public MessageClient(IBus bus)
    {
        _bus = bus;
    }

    public MessageClient()
    {
    }

    public virtual void Send<T>(T message, string topic)
    {
        _bus.PubSub.PublishAsync(message, topic);
    }
}