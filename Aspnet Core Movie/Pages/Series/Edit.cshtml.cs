using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aspnet_Core_Movie.Models;
using Aspnet_Core_Movie.Infrastructure;

namespace Aspnet_Core_Movie.Controllers
{
    public class EditModel1 : PageModel
    {
        private readonly SerieContext _context;

        public EditModel1(SerieContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SerieList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieListExists(SerieList.Id))
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

        private bool SerieListExists(int id)
        {
            return _context.SerieList.Any(e => e.Id == id);
        }
    }
}
