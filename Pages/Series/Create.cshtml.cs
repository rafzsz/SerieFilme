using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SerieFilme.Data;
using SerieFilme.Models;

namespace SerieFilme.Pages.Series
{
    public class CreateModel : PageModel
    {
        private readonly SerieFilme.Data.SerieFilmeContext _context;

        public CreateModel(SerieFilme.Data.SerieFilmeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Serie Serie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Serie.Add(Serie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}