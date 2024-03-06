using CapaDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography; // Agregar este using
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
                // Buscar el usuario por correo
                var usuario = await _con.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);

                // Verificar si se encontró un usuario
                if (usuario != null)
                {
                    // Verificar si la contraseña ingresada coincide con la contraseña almacenada
                    if (VerificarContraseña(contraseña, usuario.Contraseña))
                    {
                        return usuario; // Devolver el usuario encontrado
                    }
                }

                // Si no se encontró ningún usuario o la contraseña no coincide, devolver null
                return null;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí (opcional)
                Console.WriteLine($"Error al autenticar usuario: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> RegistrarUsuario(Usuario nuevoUsuario)
        {
            try
            {
                // Hashear la contraseña antes de almacenarla
                nuevoUsuario.Contraseña = await HashearContraseña(nuevoUsuario.Contraseña);

                _con.Usuarios.Add(nuevoUsuario);
                await _con.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<string> HashearContraseña(string contraseña)
        {
            // Crear un objeto de tipo SHA256 para hashear la contraseña
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Obtener el hash de la contraseña
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Convertir el hash a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerificarContraseña(string contraseña, string hashAlmacenado)
        {
            // Hashear la contraseña ingresada
            string hashIngresado = HashearContraseña(contraseña).Result;

            // Comparar los hashes
            return hashIngresado == hashAlmacenado;
        }
    }
}
