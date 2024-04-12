using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public interface IServicePrestamos
    {

        Task<bool> DevolverPrestamoPorNombreUsuario(string nombreUsuario, int idLibro);
        Task<bool> AgregarPrestamo(int idUsuario, int idLibro);
        Task<int?> ObtenerIdUsuarioPorNombre(string nombreUsuario);
        Task<List<int>> ObtenerIdLibrosRentadosPorUsuario(string userId);



    }
}
