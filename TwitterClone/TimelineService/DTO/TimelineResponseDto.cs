namespace TimelineService.DTO;

public class TimelineResponseDto
{
    public string Id { get; set; }
    public int UserId { get; set; }
    public ICollection<TweetResponseDto> Tweets { get; set; }

}