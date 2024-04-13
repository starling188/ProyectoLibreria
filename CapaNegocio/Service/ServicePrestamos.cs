using CapaDatos.DataContext;
using CapaDatos.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
        public class ServicePrestamos: IServicePrestamos
        {
            private readonly InterfacePrestamos _prestamosLibros;
            private readonly InterfaceUsuario _suarioLibros;
            public ServicePrestamos(InterfacePrestamos prestamosLibros, InterfaceUsuario usuario)
            {
                _prestamosLibros = prestamosLibros;
                _suarioLibros = usuario;
            }

            public async Task<bool> AgregarPrestamo(int idUsuario, int idLibro)
            {
                return await _prestamosLibros.AgregarPrestamo(idUsuario, idLibro);
            }

          
            
            //no borrar
            public async Task<int?> ObtenerIdUsuarioPorNombre(string nombreUsuario)
            {
                try
                {
                    // Buscar el usuario en base al nombre de usuario
                    var usuario = await _suarioLibros.ObtenerUsuarioPorNombre(nombreUsuario);

                    // Si el usuario existe, devolver su ID
                    if (usuario != null)
                    {
                        return usuario.IdUsuario;
                    }
                    else
                    {
                        // Si el usuario no existe, devolver null
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la búsqueda del usuario
                    Console.WriteLine($"Error al buscar el ID del usuario por nombre: {ex.Message}");
                    return null;
                }
            }


            public async Task<List<int>> ObtenerIdLibrosRentadosPorUsuario(string userId)
            {
                try
                {
                    return await _prestamosLibros.ObtenerIdLibrosRentadosPorUsuario(userId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener los ID de los libros rentados por usuario: {ex.Message}");
                    return new List<int>();
                }
            }


            public async Task<bool> DevolverPrestamoPorNombreUsuario(string nombreUsuario, int idLibro)
            {
                try
                {
                    // Obtener el ID de usuario utilizando el nombre de usuario
                    int? idUsuario = await ObtenerIdUsuarioPorNombre(nombreUsuario);

                    if (idUsuario.HasValue)
                    {
                        // Utilizar el ID de usuario para devolver el préstamo del libro
                        return await _prestamosLibros.DevolverPrestamo(idUsuario.Value, idLibro);
                    }
                    else
                    {
                        // Si no se puede obtener el ID de usuario, devuelve false
                        Console.WriteLine($"No se pudo obtener el ID de usuario para el nombre de usuario: {nombreUsuario}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante el proceso
                    Console.WriteLine($"Error al devolver el préstamo por nombre de usuario: {ex.Message}");
                    return false;
                }
            }

            public async Task<List<Prestamo>> ObtenerTodosLosPrestamos()
            {
               return await _prestamosLibros.ObtenerTodosLosPrestamos();
            }
    }

}
