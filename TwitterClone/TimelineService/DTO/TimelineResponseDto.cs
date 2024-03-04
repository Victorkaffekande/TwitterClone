namespace TimelineService.DTO;

public class TimelineResponseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<TweetResponseDto> Tweets { get; set; }

}