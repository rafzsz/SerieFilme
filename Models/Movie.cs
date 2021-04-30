using System;
using System.ComponentModel.DataAnnotations;

namespace SerieFilme.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Gênero")]
        public string Genre { get; set; }

    }
}
