namespace SGBL.Models
{
    public class PrestamoViewModel
    {
        public int IdPrestamo { get; set; }
        public string? NombreUsuario { get; set; }
        public string? TituloLibro { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string? EstadoPrestamo { get; set; }
    }
}