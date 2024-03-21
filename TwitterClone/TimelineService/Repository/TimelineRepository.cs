using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TimelineService.Models;
using TimelineService.Repository.Models;


namespace TimelineService.Repository;

public class TimelineRepository: ITimelineRepository
{
    private readonly IMongoCollection<Timeline> _timelineCollection;
    
    public TimelineRepository(IOptions<TimelineDatabaseSettings> timelineDatabaseSettings)
    {
        var client = new MongoClient(
            timelineDatabaseSettings.Value.ConnectionString);
        
        var mongoDatabase = client.GetDatabase(
            timelineDatabaseSettings.Value.DatabaseName);
        
        _timelineCollection = mongoDatabase.GetCollection<Timeline>(
            timelineDatabaseSettings.Value.TimelineCollectionName);

    }

    public Task<Timeline> GetTimelineByUserId(int id)
    {
        var filter = Builders<Timeline>.Filter.Eq("UserId", id);
        var result = _timelineCollection.Find(filter).FirstOrDefaultAsync();
        return result;
    }

    public void AddTweetToTimelines(Tweet tweet, List<int> userIds)
    {
        var update = Builders<Timeline>.Update.Push(t => t.Tweets, tweet); 
        
        foreach (var id in userIds)  
        {  
            var filter = Builders<Timeline>.Filter.Eq(t => t.UserId, id);  
            _timelineCollection.UpdateOneAsync(filter, update);  
        }  
    }
}