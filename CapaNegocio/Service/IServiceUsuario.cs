using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public interface IServiceUsuario
    {
        Task<Usuario> AutenticarUsuario(string correo, string contraseña);

        Task<bool> RegistrarUsuario(Usuario nuevoUsuario);
        Task<string> ObtenerNombreRol(int idRol);
    }
}
