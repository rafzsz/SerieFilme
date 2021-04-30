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
    public class DeleteModel : PageModel
    {
        private readonly SerieFilme.Data.SerieFilmeContext _context;

        public DeleteModel(SerieFilme.Data.SerieFilmeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serie = await _context.Serie.FindAsync(id);

            if (Serie != null)
            {
                _context.Serie.Remove(Serie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
