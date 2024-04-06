namespace TweetService;

public interface IMessageClient
{
    void Send<T>(T message, string topic);
}