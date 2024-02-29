namespace ClientAPI.DTO;

public class CreateTweetDto
{
    public int UserId { get; set; }
    public string AuthorName { get; set; }
    public string AuthorHandle { get; set; }
    public string Body { get; set; }
}