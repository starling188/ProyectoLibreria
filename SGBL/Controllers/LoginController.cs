using CapaNegocio.Service;
using Microsoft.AspNetCore.Mvc;
using SGBL.Models;


using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace SGBL.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServiceUsuario _use;

        public LoginController(IServiceUsuario use)
        {
            _use = use;   
        }

        
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(string correo, string contraseña)
        {
            // Validar si el usuario y la contraseña están presentes
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                ModelState.AddModelError(string.Empty, "El correo electrónico y la contraseña son requeridos.");
                return View();
            }

            // Autenticar al usuario
            var usuario = await _use.AutenticarUsuario(correo, contraseña);

            if (usuario != null)
            {
                var nombreRol = await _use.ObtenerNombreRol(usuario.IdRol);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Correo", usuario.Correo),
                    new Claim(ClaimTypes.Role, nombreRol),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Si el usuario es válido, redirigir al index del Home
                return RedirectToAction("Index", "Home");
            }

            return View();
        }



        public IActionResult Registro() { 
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(ViewModelUser viewModelUser)
        {
            if (ModelState.IsValid)
            {
                var nuevoUsuario = new CapaDatos.DataContext.Usuario
                {
                    Nombre = viewModelUser.Nombre,
                    Apellido = viewModelUser.Apellido,
                    Correo = viewModelUser.Correo,
                    Contraseña = viewModelUser.Password,
                    IdRol = viewModelUser.Rol
                    
                    
                    
                };

                

                var registroExitoso = await _use.RegistrarUsuario(nuevoUsuario);

                if (registroExitoso)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Hubo un error al registrar el usuario.");
                }
            }

            return View("Registro");
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }
    }

        

}



