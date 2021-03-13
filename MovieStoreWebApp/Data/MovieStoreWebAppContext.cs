using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApp.Data
{
    public class MovieStoreWebAppContext : DbContext
    {
        public MovieStoreWebAppContext (DbContextOptions<MovieStoreWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Movie> Movie { get; set; }
    }
}
