using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public interface InterfacePrestamos
    {
        Task<List<Prestamo>> ObtenerTodosLosPrestamos();

        Task<bool> DevolverPrestamo(int idUsuario, int idLibro);

        Task<bool> AgregarPrestamo(int idUsuario, int idLibro);

        Task<List<int>> ObtenerIdLibrosRentadosPorUsuario(string userId);
    }
}
