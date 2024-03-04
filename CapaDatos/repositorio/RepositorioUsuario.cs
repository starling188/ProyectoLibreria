using CapaDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.repositorio
{
    public class RepositorioUsuario : InterfaceUsuario
    {
        private readonly LibreriaTiendaContext _con;

        public RepositorioUsuario(LibreriaTiendaContext con)
        {
            _con = con;
        }

        public async Task<Usuario> AutenticarUsuario(string correo, string contraseña)
        {
            try
            {
                // Buscar el usuario por correo y contraseña
                var usuario = await _con.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo && u.Contraseña == contraseña);

                // Verificar si se encontró un usuario
                if (usuario != null)
                {
                    return usuario; // Devolver el usuario encontrado
                }
                else
                {
                    // Si no se encontró ningún usuario, devolver un valor predeterminado
                    return new Usuario(); // Aquí puedes devolver un usuario vacío o null, según tu lógica
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí (opcional)
                Console.WriteLine($"Error al autenticar usuario: {ex.Message}");
                return new Usuario(); // Devolver un usuario vacío en caso de error
            }
        }

        public async Task<bool> RegistrarUsuario(Usuario nuevoUsuario)
        {
            try
            {
                _con.Usuarios.Add(nuevoUsuario);
                await _con.SaveChangesAsync();
                return true;

            }

            catch (Exception ex) {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }
    }
}
