using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aspnet_Core_Movie.Infrastructure;
using Aspnet_Core_Movie.Models;
using Microsoft.AspNetCore.Authorization;

namespace Aspnet_Core_Movie.Controllers
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly Aspnet_Core_Movie.Infrastructure.MovieContext _context;

        public EditModel(Aspnet_Core_Movie.Infrastructure.MovieContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieListExists(MovieList.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieListExists(int id)
        {
            return _context.MovieList.Any(e => e.Id == id);
        }
    }
}
