using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SerieFilme.Data;
using SerieFilme.Models;

namespace SerieFilme.Pages.Series
{
    public class DetailsModel : PageModel
    {
        private readonly SerieFilme.Data.SerieFilmeContext _context;

        public DetailsModel(SerieFilme.Data.SerieFilmeContext context)
        {
            _context = context;
        }

        public Serie Serie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serie = await _context.Serie.FirstOrDefaultAsync(m => m.ID == id);

            if (Serie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
