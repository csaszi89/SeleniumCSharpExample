using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApp.Models;

namespace MovieStoreWebApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Data.MovieStoreWebAppContext _context;

        public IndexModel(Data.MovieStoreWebAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
