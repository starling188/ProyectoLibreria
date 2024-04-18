namespace SGBL.Models
{
    public class ViewModelUpdateLibro
    {
        public int IdLibro { get; set; }

        public string Titulo { get; set; } = null!;

        public string? nombreAutor { get; set; }

        public string? Genero { get; set; }

        public string? PalabrasClave { get; set; }

        public string? Sinopsis { get; set; }

        public bool? Disponibilidad { get; set; }
    }
}
