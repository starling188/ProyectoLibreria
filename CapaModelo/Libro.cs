using System;
using System.Collections.Generic;

namespace CapaDatos.DataContext;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string Titulo { get; set; } = null!;

    public int? IdAutor { get; set; }

    public int? IdGenero { get; set; }

    public string? PalabrasClave { get; set; }

    public string? Sinopsis { get; set; }

    public bool? Disponibilidad { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public decimal? Precio { get; set; } // Nueva propiedad para el precio


    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<HistorialTransaccione> HistorialTransacciones { get; set; } = new List<HistorialTransaccione>();

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Genero? IdGeneroNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
