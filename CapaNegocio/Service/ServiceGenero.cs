using CapaDatos.DataContext;
using CapaDatos.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public class ServiceGenero : IServiceGenero
    {
        private readonly InterfaceGeneros _genero;

        public ServiceGenero(InterfaceGeneros genero)
        {
            _genero = genero;
        }

        public async Task<bool> ActualizarGenero(Genero genero)
        {
            return await _genero.ActualizarGenero(genero);
        }

        public async Task<bool> AgregarGenero(Genero genero)
        {
            return await _genero.AgregarGenero(genero);
        }

        public async Task<bool> EliminarGenero(int id)
        {
            return await _genero.EliminarGenero(id);
        }

        public async Task<int?> ObtenerIdPorNombre(string nombre)
        {
            return await _genero.ObtenerIdPorNombre(nombre);
        }

        public async Task<Genero> ObtenerPorId(int id)
        {
            return await _genero.ObtenerPorId(id);
        }

        public async Task<List<Genero>> ObtenerTodos()
        {
            return await _genero.ObtenerTodos();
        }
    }
}
