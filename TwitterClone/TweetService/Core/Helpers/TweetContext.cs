using Microsoft.EntityFrameworkCore;
using SharedModels;


namespace TweetService;

public class TweetContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "TweetDb");
        
    }
    
    public DbSet<Tweet> Tweets { get; set; }
    
}