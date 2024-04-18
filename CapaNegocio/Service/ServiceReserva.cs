using CapaDatos.DataContext;
using CapaDatos.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public class ServiceReserva : IServiceReserva
    {
        private readonly InterfaceReservas _repoReservas;

        public ServiceReserva(InterfaceReservas repoReservas)
        {
            _repoReservas = repoReservas;
        }

        public async Task<bool> ReservarLibro(int idUsuario, int idLibro)
        {
            return await _repoReservas.ReservarLibro(idUsuario, idLibro);
        }

        public async Task<bool> CancelarReserva(int idReserva)
        {
            return await _repoReservas.CancelarReserva(idReserva);
        }

        public async Task<List<Reserva>> ObtenerReservasPorUsuario(int idUsuario)
        {
            return await _repoReservas.ObtenerReservasPorUsuario(idUsuario);
        }
    }
}
