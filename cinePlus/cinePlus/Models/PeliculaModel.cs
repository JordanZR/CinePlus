using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cinePlus.Models
{
    public class PeliculaModel
    {
        [Required]
        public int PeliculaID { get; set; }
        [Required]

        public string PosterImagen { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]

        public string Sinopsis { get; set; }
        [Required]

        public string Director { get; set; }
        [Required]

        public string Genero { get; set; }
        [Required]

        public int Puntos { get; set; }
    }
}
