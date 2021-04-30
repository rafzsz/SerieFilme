using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SerieFilme.Models;

namespace SerieFilme.Data
{
    public class SerieFilmeContext : DbContext
    {
        public SerieFilmeContext (DbContextOptions<SerieFilmeContext> options)
            : base(options)
        {
        }

        public DbSet<SerieFilme.Models.Movie> Movie { get; set; }

        public DbSet<SerieFilme.Models.Serie> Serie { get; set; }
    }
}
