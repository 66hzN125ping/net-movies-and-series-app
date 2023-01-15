using Aspnet_Core_Movie.Infrastructure;
using Aspnet_Core_Movie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet_Core_Movie.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SerieContext context;
        public SeriesController(SerieContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult> Index()
        {
            IQueryable<SerieList> items = from i in context.SerieList orderby i.Id select i;

            List<SerieList> serieList = await items.ToListAsync();

            return View(serieList);
        }
    }
}
