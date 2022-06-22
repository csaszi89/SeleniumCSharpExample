using MovieStoryWebApp.Test.Utils.Models;
using System.Data.Entity;

namespace MovieStoreWebApp.Test.Utils
{
    public partial class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext()
            : base("name=MovieStoreDbContext")
        {
        }

        public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
