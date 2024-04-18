using CapaDatos.DataContext;
using CapaDatos.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public class ServiceAutor : IServiceAutor
    {
        private readonly InterfaceAutor _autor;

        public ServiceAutor(InterfaceAutor autor)
        {
            _autor = autor;
        }

        public async Task<bool> ActualizarAutor(Autor autor)
        {
            return await _autor.ActualizarAutor(autor);
        }

        public async Task<bool> AgregaAutor(Autor autor)
        {
            return await _autor.AgregarAutor(autor);
        }

        public async Task<bool> EliminarAutor(int id)
        {
            return await _autor.EliminarAutor(id);
        }

     
        public async Task<int?> ObtenerIdPorNombre(string nombre)
        {
            return await _autor.ObtenerIdPorNombre(nombre);
        }

        public Task<Autor> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Autor>> ObtenerTodos()
        {
            return await _autor.ObtenerTodos();
        }




    }
}
