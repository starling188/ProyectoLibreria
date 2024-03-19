using System.ComponentModel.DataAnnotations;

namespace SGBL.Models
{
    public class ViewModelAutor
    {
        [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del autor es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La Nacionalidad es obligatorio.")]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "El Fecha de Nacimiento es obligatorio.")]
        [Display(Name = "Fecha de nacimiento")]
        public DateOnly FechaNacimiento { get; set; }

       
    }
}
