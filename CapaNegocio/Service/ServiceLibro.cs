using CapaDatos.DataContext;
using CapaDatos.repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   


namespace CapaNegocio.Service
{
    public class ServiceLibro : IServiceLibro
    {

        private readonly InterfaceLibro _libro;
        private readonly IServiceAutor _serviceAutor;
        private readonly IServiceGenero _serviceGenero;

        public ServiceLibro(InterfaceLibro libro, IServiceAutor serviceAutor, IServiceGenero serviceGenero)
        {
            _libro = libro;
            _serviceAutor = serviceAutor;
            _serviceGenero = serviceGenero;
        }

        public async Task<bool> ActualizarLibro(Libro libro)
        {
            return await _libro.ActualizarLibro(libro);
        }

        public async Task<bool> AgregarLibro(Libro libro)
        {
            return await _libro.AgregarLibro(libro);
        }

        public async Task<List<Libro>> BuscarLibros(string criterio)
        {
            // Buscar libros por título, autor, género o palabras clave
            var libros = await _libro.ObtenerTodos();

            return libros
                .Where(libro =>
                    libro.Titulo.Contains(criterio) ||
                    (libro.IdAutorNavigation != null && (libro.IdAutorNavigation.Nombre.Contains(criterio) || libro.IdAutorNavigation.Apellido.Contains(criterio))) ||
                    (libro.IdGeneroNavigation != null && libro.IdGeneroNavigation.Nombre.Contains(criterio)) ||
                    libro.PalabrasClave.Contains(criterio))
                .ToList();
        }

        public async Task<bool> EliminarLibro(int id)
        {
            return await _libro.EliminarLibro(id);
        }

        public async Task<Libro> ObtenerPorId(int id)
        {
            return await _libro.ObtenerPorId(id);
        }

        public async Task<List<Libro>> ObtenerTodos()
        {
            // Obtener una consulta IQueryable para los libros
            return await _libro.ObtenerTodos();
        }



    }
}
