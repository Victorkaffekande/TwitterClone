namespace SharedModels;

public class Tweet
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AuthorName { get; set; }
    public string AuthorHandle { get; set; }
    public string Body { get; set; }
    public DateTime Timestamp { get; set; }
}