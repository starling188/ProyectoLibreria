using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public interface IServiceLibro
    {

        Task<List<Libro>> ObtenerTodos();
        Task<Libro> ObtenerPorId(int id);
        Task<bool> AgregarLibro(Libro libro);
        Task<bool> ActualizarLibro(Libro libro);
        Task<bool> EliminarLibro(int id);

  
        Task<List<Libro>> BuscarLibros(string criterio);

    }
}
