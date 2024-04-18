using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public interface InterfaceGeneros
    {
        Task<List<Genero>> ObtenerTodos();
        Task<Genero> ObtenerPorId(int id);
        Task<bool> AgregarGenero(Genero autor);
        Task<bool> ActualizarGenero(Genero autor);
        Task<bool> EliminarGenero(int id);

        Task<int?> ObtenerIdPorNombre(string nombre);
    }
}
