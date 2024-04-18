using CapaDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public class RepositorioGeneros : InterfaceGeneros
    {
        private readonly LibreriaTiendaContext _context;

        public RepositorioGeneros(LibreriaTiendaContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarGenero(Genero genero)
        {
            try
            {
                _context.Entry(genero).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AgregarGenero(Genero genero)
        {
            try
            {
                _context.Generos.Add(genero);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarGenero(int id)
        {
            try
            {
                var genero = await _context.Generos.FindAsync(id);
                if (genero == null)
                    return false;

                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Genero> ObtenerPorId(int id)
        {
            return await _context.Generos.FindAsync(id);
        }

        public async Task<List<Genero>> ObtenerTodos()
        {
            return await _context.Generos.ToListAsync();
        }


        public async Task<int?> ObtenerIdPorNombre(string nombre)
        {
            var genero = await _context.Generos.FirstOrDefaultAsync(g => g.Nombre == nombre);
            return genero?.IdGenero;
        }

    }
}
