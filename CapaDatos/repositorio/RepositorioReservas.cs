using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos.repositorio
{
    public  class RepositorioReservas : InterfaceReservas
    {

        private readonly LibreriaTiendaContext _context;

        public RepositorioReservas(LibreriaTiendaContext context)
        {
            _context = context;
        }

        public async Task<bool> ReservarLibro(int idUsuario, int idLibro)
        {
            try
            {
                // Verificar si el libro está disponible
                var libro = await _context.Libros.FindAsync(idLibro);
                if (libro == null || libro.Disponibilidad == false)
                {
                    return false; // Libro no disponible o no encontrado
                }

                // Crear una nueva reserva
                var nuevaReserva = new Reserva
                {
                    IdUsuario = idUsuario,
                    IdLibro = idLibro,
                    FechaReserva = DateTime.Now,
                    EstadoReserva = "Pendiente"
                };

                _context.Reservas.Add(nuevaReserva);
                await _context.SaveChangesAsync();

                return true; // Reserva exitosa
            }
            catch (Exception)
            {
                // Manejar la excepción según lo necesites
                return false;
            }
        }

        public async Task<bool> CancelarReserva(int idReserva)
        {
            try
            {
                var reserva = await _context.Reservas.FindAsync(idReserva);
                if (reserva == null || reserva.EstadoReserva != "Pendiente")
                {
                    return false; // Reserva no encontrada o no está pendiente
                }

                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();

                return true; // Cancelación exitosa
            }
            catch (Exception)
            {
                return false; // Manejar la excepción según lo necesites
            }
        }

        public async Task<List<Reserva>> ObtenerReservasPorUsuario(int idUsuario)
        {
            return await _context.Reservas
               .Include(r => r.IdLibroNavigation)  // Cargar la navegación del libro
               .Where(r => r.IdUsuario == idUsuario)
               .ToListAsync();
        }
    }
}

