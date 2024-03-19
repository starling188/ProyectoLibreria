using System.ComponentModel.DataAnnotations;

namespace SGBL.Models
{
    public class ViewModelGeneros
    {
        [Required(ErrorMessage = "El nombre del género es obligatorio.")]
        public string Nombre { get; set; }
    }
}
