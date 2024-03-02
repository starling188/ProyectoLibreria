using CapaNegocio.Service;
using Microsoft.AspNetCore.Mvc;

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

            // Verificar si se encontró el usuario
            if (usuario != null)
            {
                // Si el usuario es válido, redirigir al index del Home
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Si el usuario no es válido, agregar un error de modelo y volver a la vista de login
                ModelState.AddModelError(string.Empty, "El correo electrónico o la contraseña son incorrectos.");
                return View();
            }
        }
    }
}
