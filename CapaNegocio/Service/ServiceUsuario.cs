using CapaDatos.DataContext;
using CapaDatos.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Service
{
    public class ServiceUsuario : IServiceUsuario
    {

        private readonly InterfaceUsuario _use;

        public ServiceUsuario(InterfaceUsuario use)
        {
            _use = use;
        }

        public async Task<Usuario> AutenticarUsuario(string correo, string contraseña)
        {
            return await _use.AutenticarUsuario(correo,contraseña);
        }
    }
}
