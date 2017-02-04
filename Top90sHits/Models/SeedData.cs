using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Top90sHits.Data;
using System;
using System.Linq;

namespace Top90sHits.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.TheHits.Any())
                {
                    return;   // DB has been seeded
                }

                context.TheHits.AddRange(
                     new TheHits
                     {
                         Title = "My Name Is",
                         ReleaseDate = DateTime.Parse("1999-1-11"),
                         Genre = "Hip Hop",
                         Artist = "Eminem"
                     },

                     new TheHits
                     {
                         Title = "Mr Jones",
                         ReleaseDate = DateTime.Parse("1993-3-13"),
                         Genre = "Rock",
                         Artist = "Counting Crows"
                     },

                     new TheHits
                     {
                         Title = "Ice Ice Baby",
                         ReleaseDate = DateTime.Parse("1990-2-23"),
                         Genre = "Hip Hop",
                         Artist = "Vanilla Ice"
                     },

                   new TheHits
                   {
                       Title = "Wonderwall",
                       ReleaseDate = DateTime.Parse("1995-4-15"),
                       Genre = "Rock",
                       Artist = "Oasis"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}