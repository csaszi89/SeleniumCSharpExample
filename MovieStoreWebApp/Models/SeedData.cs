using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreWebApp.Data;
using System;
using System.Linq;

namespace MovieStoreWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreWebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieStoreWebAppContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Titanic",
                        ReleaseDate = DateTime.Parse("1998-1-22"),
                        Genre = "Drama",
                        Price = 7.99M,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        Title = "Scream",
                        ReleaseDate = DateTime.Parse("1998-5-7"),
                        Genre = "Horror",
                        Price = 8.99M,
                        Rating = "NC-17"
                    },
                    new Movie
                    {
                        Title = "American Pie",
                        ReleaseDate = DateTime.Parse("1999-12-2"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "The Lion King",
                        ReleaseDate = DateTime.Parse("1994-06-12"),
                        Genre = "Animation",
                        Price = 6.99M,
                        Rating = "G"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}