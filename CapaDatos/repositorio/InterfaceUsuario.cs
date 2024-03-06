using CapaDatos.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public interface InterfaceUsuario
    {
        Task<Usuario> AutenticarUsuario(string correo, string contraseña);

        Task<bool> RegistrarUsuario(Usuario nuevoUsuario);

        Task<string> HashearContraseña(string contraseña);
    }
}
