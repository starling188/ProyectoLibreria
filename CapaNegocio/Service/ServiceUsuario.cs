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
        //logica

        private readonly InterfaceUsuario _use;

        public ServiceUsuario(InterfaceUsuario use)
        {
            _use = use;
        }

        public async Task<Usuario> AutenticarUsuario(string correo, string contraseña)
        {

            return await _use.AutenticarUsuario(correo,contraseña);
        }

        public async Task<bool> RegistrarUsuario(Usuario nuevoUsuario)
        {
            return await _use.RegistrarUsuario(nuevoUsuario);
        }

        public async Task<string> ObtenerNombreRol(int idRol)
        {
            return await _use.ObtenerNombreRol(idRol);
        }


    }
}
