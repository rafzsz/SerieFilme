using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerieFilme.Data;
using SerieFilme.Models;

namespace SerieFilme.Pages.Series
{
    public class EditModel : PageModel
    {
        private readonly SerieFilme.Data.SerieFilmeContext _context;

        public EditModel(SerieFilme.Data.SerieFilmeContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(Serie.ID))
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

        private bool SerieExists(int id)
        {
            return _context.Serie.Any(e => e.ID == id);
        }
    }
}
