using Aspnet_Core_Movie.Model;
using Aspnet_Core_Movie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet_Core_Movie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext context;
        public MoviesController(MovieContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult> Index()
        {
            IQueryable<MovieList> items = from i in context.MovieList orderby i.Id select i;

            List<MovieList> movieList = await items.ToListAsync();

            return View(movieList);
        }
    }
}
