using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using SharedModels;


namespace TweetService;

public class TweetRepository : ITweetRepository
{
    private readonly TweetContext _tweetContext;

    public TweetRepository(TweetContext tweetContext)
    {
        _tweetContext = tweetContext;
        SeedData();
    }

    private void SeedData()
    {
        if (_tweetContext.Tweets.ToList().Count != 0)
        {
            return;
        }

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
        //TODO Fake Data setup
        //Kinda messy that this code is called everytime its initialised in the TweetService, alternative idea is to move code into method.

        _tweetContext.Tweets.AddRange(tweets);
        _tweetContext.SaveChanges();
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