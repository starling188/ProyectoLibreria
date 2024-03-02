using System;
using System.Collections.Generic;

namespace CapaDatos.DataContext;

public partial class HistorialTransaccione
{
    public int IdTransaccion { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdLibro { get; set; }

    public string? TipoTransaccion { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
