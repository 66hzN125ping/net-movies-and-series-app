using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aspnet_Core_Movie.Models;
using Aspnet_Core_Movie.Infrastructure;

namespace Aspnet_Core_Movie.Controllers
{
    public class CreateModel1 : PageModel
    {
        private readonly SerieContext _context;

        public CreateModel1(SerieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SerieList SerieList { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SerieList.Add(SerieList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
