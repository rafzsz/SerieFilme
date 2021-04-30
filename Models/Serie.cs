using System;
using System.ComponentModel.DataAnnotations;

namespace SerieFilme.Models
{
    public class Serie
    {
        public int ID { get; set; }
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Gênero")]
        public string Genre { get; set; }
        [Display(Name = "Temporada")]
        public string Temp { get; set; }
        [Display(Name = "Episódio")]
        public string Epi { get; set; }
    }
}
