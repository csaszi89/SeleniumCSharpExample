using MovieStoryWebApp.Test.Utils.Models;
using System.Linq;

namespace MovieStoreWebApp.Test.Utils.DbHandlers
{
    public class MoviesHandler
    {
        public MoviesHandler()
        {
        }

        public void Create(Movie movie)
        {
            Argument.VerifyNotNull(movie);

            using (var context = new MovieStoreDbContext())
            {
                if (!context.Movie.Any(m => m.Title == movie.Title))
                {
                    context.Movie.Add(movie);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(string title)
        {
            Argument.VerifyNotNull(title);

            using (var context = new MovieStoreDbContext())
            {
                var movie = context.Movie.FirstOrDefault(m => m.Title == title);

                if (movie != null)
                {
                    context.Movie.Remove(movie);
                    context.SaveChanges();
                }
            }
        }
    }
}
