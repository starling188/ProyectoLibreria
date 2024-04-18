using CapaDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public class RepositorioAutor : InterfaceAutor
    {
        private readonly LibreriaTiendaContext _context;

        public RepositorioAutor(LibreriaTiendaContext p)
        {
            _context = p;
        }

        public async Task<bool> ActualizarAutor(Autor autor)
        {
            try
            {
                _context.Entry(autor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AgregarAutor(Autor autor)
        {
            try
            {
                _context.Autors.Add(autor) ;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarAutor(int id)
        {
            try
            {
                var autor = await _context.Autors.FindAsync(id);
                if (autor == null)
                    return false;

                _context.Autors.Remove(autor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Autor> ObtenerPorId(int id)
        {
            return await _context.Autors.FindAsync(id);
        }

        public async Task<List<Autor>> ObtenerTodos()
        {
            return await _context.Autors.ToListAsync();
        }


        public async Task<int?> ObtenerIdPorNombre(string nombre)
        {
            var autor = await _context.Autors.FirstOrDefaultAsync(a => a.Nombre == nombre);
            return autor?.IdAutor;
        }

    }
}

