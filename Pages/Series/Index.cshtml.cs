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
    public class IndexModel : PageModel
    {
        private readonly SerieFilme.Data.SerieFilmeContext _context;

        public IndexModel(SerieFilme.Data.SerieFilmeContext context)
        {
            _context = context;
        }

        public IList<Serie> Serie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SerieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Serie
                                            orderby m.Genre
                                            select m.Genre;

            var series = from m in _context.Serie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                series = series.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SerieGenre))
            {
                series = series.Where(x => x.Genre == SerieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Serie = await series.ToListAsync();
        }
    }
}
