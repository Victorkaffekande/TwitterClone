using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace TweetService;

public interface ITweetContext
{
    DbSet<Tweet> Tweets { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}