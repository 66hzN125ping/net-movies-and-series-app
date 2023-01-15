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
    public class DeleteModel1 : PageModel
    {
        private readonly SerieContext _context;

        public DeleteModel1(SerieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SerieList SerieList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SerieList = await _context.SerieList.FirstOrDefaultAsync(m => m.Id == id);

            if (SerieList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SerieList = await _context.SerieList.FindAsync(id);

            if (SerieList != null)
            {
                _context.SerieList.Remove(SerieList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
