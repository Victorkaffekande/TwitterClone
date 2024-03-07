using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using TimelineService.Models;

namespace TimelineService.Mappers;

public static class MongoDbMapping  
{  
    public static void RegisterClassMaps()  
    {  
        BsonClassMap.RegisterClassMap<Tweet>(cm =>  
        {  
            cm.MapMember(c => c.Id).SetIsRequired(true);
            cm.MapMember(c => c.UserId).SetIsRequired(true);  
            cm.MapMember(c => c.AuthorName).SetIsRequired(true);  
            cm.MapMember(c => c.AuthorHandle).SetIsRequired(true);  
            cm.MapMember(c => c.Body).SetIsRequired(true);  
            cm.MapMember(c => c.Timestamp).SetIsRequired(true);  
        });  
  
        BsonClassMap.RegisterClassMap<Timeline>(cm =>  
        {
            cm.MapIdMember(c => c.Id)  
                .SetSerializer(new StringSerializer(BsonType.ObjectId))  // Use ObjectId as string  
                .SetIdGenerator(StringObjectIdGenerator.Instance);
            cm.MapMember(c => c.UserId).SetIsRequired(true);  
            cm.MapMember(c => c.Tweets).SetIsRequired(true);  
        });  
    }  
}