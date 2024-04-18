using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public interface InterfaceAutor
    {

        Task<List<Autor>> ObtenerTodos();
        Task<Autor> ObtenerPorId(int id);
        Task<bool> AgregarAutor(Autor autor);
        Task<bool> ActualizarAutor(Autor autor);
        Task<bool> EliminarAutor(int id);

        Task<int?> ObtenerIdPorNombre(string nombre);
    }
}
