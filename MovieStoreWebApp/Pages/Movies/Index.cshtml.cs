using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApp.Models;
using System.Linq;

namespace MovieStoreWebApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Data.MovieStoreWebAppContext _context;

        public IndexModel(Data.MovieStoreWebAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var genreQuery = _context.Movie.OrderBy(m => m.Genre).Select(m => m.Genre);
            var movies = _context.Movie.Select(m => m);

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(m => m.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(m => m.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
