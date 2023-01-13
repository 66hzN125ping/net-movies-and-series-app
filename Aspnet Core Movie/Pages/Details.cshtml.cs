﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aspnet_Core_Movie.Infrastructure;
using Aspnet_Core_Movie.Models;

namespace Aspnet_Core_Movie.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Aspnet_Core_Movie.Infrastructure.MovieContext _context;

        public DetailsModel(Aspnet_Core_Movie.Infrastructure.MovieContext context)
        {
            _context = context;
        }

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
    }
}