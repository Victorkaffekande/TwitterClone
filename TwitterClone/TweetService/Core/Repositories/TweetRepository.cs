using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using TweetService.Models;

namespace TweetService;

public class TweetRepository : ITweetRepository
{

    public TweetRepository()
    {
        using (var context = new TweetContext())
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
            context.Tweets.AddRange(tweets);
            context.SaveChanges();
        }
    }
    
    public List<Tweet> GetTweets()
    {
        using (var context = new TweetContext())
        {

            var list = context.Tweets
                .ToList();
            return list;

        }
    }

    public Tweet SaveTweet(Tweet tweet)
    {
        using (var context = new TweetContext())
        {
            context.Tweets.Add(tweet);
            context.SaveChanges();
            return tweet;
        }
        
    }
}