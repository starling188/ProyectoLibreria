using CapaDatos.DataContext;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGBL.Models
{
    public class ViewModelLibro
    {

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor del libro es obligatorio.")]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "El género del libro es obligatorio.")]
        public int IdGenero { get; set; }

        public string PalabrasClave { get; set; }

        public string Sinopsis { get; set; }

        public bool? Disponibilidad { get; set; }

        public List<Autor> Autores { get; set; } = new List<Autor>();
        public List<Genero> Generos { get; set; } = new List<Genero>();

    }
}
