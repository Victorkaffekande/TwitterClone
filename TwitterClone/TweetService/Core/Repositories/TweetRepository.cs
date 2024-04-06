using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using SharedModels;


namespace TweetService;

public class TweetRepository : ITweetRepository
{
    private readonly ITweetContext _tweetContext;

    public TweetRepository(ITweetContext tweetContext)
    {
        _tweetContext = tweetContext;
       SeedData();
    }

    private async Task SeedData()
    {
        if (!await _tweetContext.Tweets.AnyAsync())
        {
            var tweets = new List<Tweet>
            {
                new Tweet
                {
                    AuthorHandle = "Gugerel27",
                    Body = "i just got my new bike today",
                    Id = 1,
                    Timestamp = DateTime.Now,
                    AuthorName = "Victor",
                    UserId = 1,
                },
                new Tweet
                {
                    AuthorHandle = "magn20",
                    Body = "i just saw victor fall of his bike",
                    Id = 2,
                    Timestamp = DateTime.Now,
                    AuthorName = "Magnus",
                    UserId = 2,
                },
                new Tweet
                {
                    AuthorHandle = "Gugerel27",
                    Body = "i am searching for a new bike",
                    Id = 3,
                    Timestamp = DateTime.Now,
                    AuthorName = "Victor",
                    UserId = 1,
                }
            };

            await _tweetContext.Tweets.AddRangeAsync(tweets);
            await _tweetContext.SaveChangesAsync();
        }
    }

    //Just for testing purpose 
    public async Task<List<Tweet>> GetTweets()
    {
        var list = await _tweetContext.Tweets
            .ToListAsync();
        return list;
    }


    public async Task<Tweet> SaveTweet(Tweet tweet)
    {
        await _tweetContext.Tweets.AddAsync(tweet);
        await _tweetContext.SaveChangesAsync();
        return tweet;
    }
}