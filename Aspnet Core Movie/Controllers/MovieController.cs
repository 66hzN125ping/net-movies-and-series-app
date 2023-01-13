using Aspnet_Core_Movie.Infrastructure;
using Aspnet_Core_Movie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet_Core_Movie.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext context;
        public MovieController(MovieContext context)
        {
            this.context = context;
        }
        //GET /
        public async Task<ActionResult> Index()
        {
            IQueryable<MovieList> items = from i in context.MovieList orderby i.Id select i;

            List<MovieList> movieList = await items.ToListAsync();

            return View(movieList);
        }
    }
}
