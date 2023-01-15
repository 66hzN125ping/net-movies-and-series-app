using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aspnet_Core_Movie.Models;
using Aspnet_Core_Movie.Infrastructure;

namespace Aspnet_Core_Movie.Controllers
{
    public class IndexModel1 : PageModel
    {
        private readonly SerieContext _context;

        public IndexModel1(SerieContext context)
        {
            _context = context;
        }

        public IList<SerieList> SerieList { get;set; }

        public async Task OnGetAsync()
        {
            SerieList = await _context.SerieList.ToListAsync();
        }
    }
}
