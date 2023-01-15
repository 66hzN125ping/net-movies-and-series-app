using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aspnet_Core_Movie.Models;
using Microsoft.AspNetCore.Authorization;
using Aspnet_Core_Movie.Model;

namespace Aspnet_Core_Movie.Controllers
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly MovieContext _context;

        public DeleteModel(MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieList MovieList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieList = await _context.MovieList.FirstOrDefaultAsync(m => m.Id == id);

            if (MovieList == null)
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

            MovieList = await _context.MovieList.FindAsync(id);

            if (MovieList != null)
            {
                _context.MovieList.Remove(MovieList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
