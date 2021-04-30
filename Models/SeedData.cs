using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SerieFilme.Data;
using System;
using System.Linq;

namespace SerieFilme.Models {
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SerieFilmeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SerieFilmeContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Comédia Romantica",
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comédia",
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comédia",
                    },

                    new Movie
                    {
                        Title = "Harry Potter e a Pedra Filosofal",
                        ReleaseDate = DateTime.Parse("2001-4-15"),
                        Genre = "Aventura",
                    }
                );
                context.Serie.AddRange(
                    new Serie
                    {
                        Title = "The Circle",
                        ReleaseDate = DateTime.Parse("2021-2-3"),
                        Genre = "Reality Show",
                        Temp = "2ª temporada",
                        Epi = "5",
                    },

                    new Serie
                    {
                        Title = "A Million Little Things",
                        ReleaseDate = DateTime.Parse("2020-3-12"),
                        Genre = "Drama",
                        Temp = "4ª Temporada",
                        Epi = "2",
                    },

                    new Serie
                    {
                        Title = "Sex Education",
                        ReleaseDate = DateTime.Parse("2020-5-17"),
                        Genre = "Comédia",
                        Temp = "2ª Temporada",
                        Epi = "3",
                    },

                    new Serie
                    {
                        Title = "Dexter",
                        ReleaseDate = DateTime.Parse("2017-4-15"),
                        Genre = "Suspense",
                        Temp = "4ª Temporada",
                        Epi = "21",
                    });
                context.SaveChanges();
            }
        }
    }
}