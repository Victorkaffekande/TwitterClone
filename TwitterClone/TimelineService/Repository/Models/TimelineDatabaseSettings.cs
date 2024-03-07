namespace TimelineService.Repository.Models;

public class TimelineDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string TimelineCollectionName { get; set; } = null!;
}