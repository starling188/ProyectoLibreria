using CapaDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public class RepositorioPrestamos : InterfacePrestamos
    {

        private readonly LibreriaTiendaContext _contexto;

        public RepositorioPrestamos(LibreriaTiendaContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> AgregarPrestamo(int idUsuario, int idLibro)
        {


            try
            {
                var prestamo = new Prestamo
                {
                    IdUsuario = idUsuario,
                    IdLibro = idLibro,
                    FechaPrestamo = DateTime.Now,
                    EstadoPrestamo = "Prestado" // O cualquier otro estado inicial que desees
                };

                _contexto.Prestamos.Add(prestamo);
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el préstamo: {ex.Message}");
                return false;
            }
        }



        public async Task<List<int>> ObtenerIdLibrosRentadosPorUsuario(string userId)
        {
            try
            {
                // Obtener los ID de los libros rentados por el usuario con estado "Prestado"
                var idLibrosRentados = await _contexto.Prestamos
                    .Where(p => p.IdUsuario.ToString() == userId && p.EstadoPrestamo == "Prestado") // Solo obtener los préstamos con estado "Prestado"
                    .Select(p => p.IdLibro)
                    .Where(id => id.HasValue) // Excluir los valores nulos
                    .Select(id => id.Value) // Convertir los enteros nulos a enteros
                    .ToListAsync();

                return idLibrosRentados;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la obtención de los ID de libros rentados
                Console.WriteLine($"Error al obtener los ID de los libros rentados por usuario: {ex.Message}");
                return new List<int>(); // Devolver una lista vacía en caso de error
            }
        }

        public async Task<bool> DevolverPrestamo(int idUsuario, int idLibro)
        {
            try
            {
                // Buscar el préstamo asociado al usuario y al libro con estado "Prestado"
                var prestamo = await _contexto.Prestamos
                    .FirstOrDefaultAsync(p => p.IdUsuario == idUsuario && p.IdLibro == idLibro && p.EstadoPrestamo == "Prestado");

                // Verificar si se encontró el préstamo
                if (prestamo != null)
                {
                    // Cambiar el estado del préstamo a "Devuelto"
                    prestamo.EstadoPrestamo = "Devuelto";

                    // Guardar los cambios en la base de datos
                    await _contexto.SaveChangesAsync();

                    return true;
                }
                else
                {
                    // Si no se encuentra el préstamo, devuelve false
                    Console.WriteLine($"No se encontró un préstamo activo para el usuario con ID {idUsuario} y el libro con ID {idLibro}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso
                Console.WriteLine($"Error al devolver el préstamo: {ex.Message}");
                return false;
            }
        }




    }
}
