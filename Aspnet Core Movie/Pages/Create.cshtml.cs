using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aspnet_Core_Movie.Infrastructure;
using Aspnet_Core_Movie.Models;

namespace Aspnet_Core_Movie.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly Aspnet_Core_Movie.Infrastructure.MovieContext _context;

        public CreateModel(Aspnet_Core_Movie.Infrastructure.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieList MovieList { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieList.Add(MovieList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
