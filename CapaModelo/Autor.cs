using System;
using System.Collections.Generic;

namespace CapaDatos.DataContext;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Nacionalidad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public DateOnly? FechaDefuncion { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
