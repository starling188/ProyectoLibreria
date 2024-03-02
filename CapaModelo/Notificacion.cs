using System;
using System.Collections.Generic;

namespace CapaDatos.DataContext;

public partial class Notificacion
{
    public int IdNotificacion { get; set; }

    public int? IdUsuario { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public bool? Leido { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
