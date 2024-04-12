using CapaDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public class RepositorioLibro : InterfaceLibro
    {
        private readonly LibreriaTiendaContext _context;

        public RepositorioLibro(LibreriaTiendaContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarLibro(Libro libro)
        {
            try
            {
                _context.Entry(libro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AgregarLibro(Libro libro)
        {
            try
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarLibro(int id)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(id);
                if (libro == null)
                    return false;

                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Libro> ObtenerPorId(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task<List<Libro>> ObtenerTodos()
        {
            return await _context.Libros
                .Include(libro => libro.IdAutorNavigation)
                .Include(libro => libro.IdGeneroNavigation)
                .ToListAsync();
        }

       

    }
}
