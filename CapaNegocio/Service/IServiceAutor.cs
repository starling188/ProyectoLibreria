using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public interface IServiceAutor
    {
        Task<List<Autor>> ObtenerTodos();
        Task<Autor> ObtenerPorId(int id);
        Task<bool> AgregaAutor(Autor autor);
        Task<bool> ActualizarAutor(Autor autor);
        Task<bool> EliminarAutor(int id);
    }
}
