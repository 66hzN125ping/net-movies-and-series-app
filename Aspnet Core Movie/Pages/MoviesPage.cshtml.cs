using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aspnet_Core_Movie.Infrastructure;
using Aspnet_Core_Movie.Models;
using Microsoft.AspNetCore.Authorization;

namespace Aspnet_Core_Movie.Controllers
{
    [Authorize]
    public class MoviesPage : PageModel
    {
        private readonly MovieContext _context;

        public MoviesPage(MovieContext context)
        {
            _context = context;
        }

        public IList<MovieList> MovieList { get; set; }

        public async Task OnGetAsync()
        {
            MovieList = await _context.MovieList.ToListAsync();
        }
    }
}
