/*
The Entitiy Framework is used to generate SQL from .NET objects.
*/

using Microsoft.EntityFrameworkCore;

namespace TacoTracker.Models
{
    public class TacoTrackerContext : DbContext
    {
        public TacoTrackerContext(DbContextOptions<TacoTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Guess> Guesses { get; set; }


    }
}
