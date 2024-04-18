using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public interface IServiceReserva
    {
        Task<bool> CancelarReserva(int idReserva);
        Task<bool> ReservarLibro(int idUsuario, int idLibro);

        Task<List<Reserva>> ObtenerReservasPorUsuario(int idUsuario);
    }
}
