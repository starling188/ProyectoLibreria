using System.ComponentModel.DataAnnotations;

namespace SGBL.Models
{
    public class ViewModelUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [DataType(DataType.Text)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido.")]
        [DataType(DataType.Text)]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [DataType(DataType.Text)]
        public string? Correo { get; set; }



        [Compare(nameof(Password),ErrorMessage ="deben coincidir las contrasenas")]
        [Required(ErrorMessage ="debe colocar la contrasena")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        [Required(ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public int Rol { get; set; } = 2;
    }
}
