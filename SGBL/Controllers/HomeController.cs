using CapaDatos.DataContext;
using CapaNegocio.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGBL.Models;
using System.Diagnostics;

namespace SGBL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceLibro _ser;
        private readonly IServiceGenero _serviceGenero;
        private readonly IServiceAutor _serviceAutor;


        public HomeController(ILogger<HomeController> logger, IServiceLibro serviceLibro, IServiceGenero serviceGenero, IServiceAutor serviceAutor)
        {
            _logger = logger;
            _ser = serviceLibro;
            _serviceGenero = serviceGenero;
            _serviceAutor = serviceAutor;
        }

        public async Task<IActionResult> Index()
        {
            List<Libro> libros = await _ser.ObtenerTodos();
            return View(libros);
        }

        [HttpPost]
        public async Task<IActionResult> Buscar(string criterio)
        {
            if (string.IsNullOrEmpty(criterio))
            {
                // Si el criterio de búsqueda está vacío, redirige al método Index para mostrar todos los libros
                return RedirectToAction("Index");
            }

            // Realizar la búsqueda de libros utilizando el criterio
            List<Libro> librosEncontrados = await _ser.BuscarLibros(criterio);

            // Devolver la vista con los libros encontrados
            return View("Index", librosEncontrados);
        }






        public IActionResult Privacy()
        {
            return View();
        }


        [Authorize(Roles ="Admin")]
        public IActionResult AgregarAutor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAutor(ViewModelAutor nuevoAutor)
        {
            if (ModelState.IsValid)
            {
                var autor = new Autor
                {
                    Nombre = nuevoAutor.Nombre,
                    Apellido = nuevoAutor.Apellido,
                    Nacionalidad = nuevoAutor.Nacionalidad,
                    FechaNacimiento = nuevoAutor.FechaNacimiento,
                    
                };

                // Intenta agregar el nuevo autor
                bool registroExitoso =  await _serviceAutor.AgregaAutor(autor);

                if (registroExitoso)
                {
                    // Redirige a la acción Index si el registro fue exitoso
                    return RedirectToAction("Index");
                }
                else
                {
                    // Si hay un error al agregar el autor, muestra un mensaje de error
                    ModelState.AddModelError(string.Empty, "Hubo un error al agregar el autor.");
                }
            }

            // Si el modelo no es válido, regresa a la vista de AgregarAutor con el modelo
            return View(nuevoAutor);
        }


        [Authorize(Roles ="Admin")]
        public IActionResult AgregarGenero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarGenero(ViewModelGeneros nuevoGenero)
        {
            if (ModelState.IsValid)
            {
                var genero = new Genero
                {
                    Nombre = nuevoGenero.Nombre
                };

                bool registroExitoso = await _serviceGenero.AgregarGenero(genero);

                if (registroExitoso)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Hubo un error al agregar el género.");
                }
            }

            return View(nuevoGenero);
        }


        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AgregarLibro()
        {
            var viewModel = new ViewModelLibro
            {
                Autores = await _serviceAutor.ObtenerTodos(),
                Generos = await _serviceGenero.ObtenerTodos()
            };
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AgregarLibro(ViewModelLibro nuevoLibro)
        {
            if (ModelState.IsValid)
            {
                // Crear un nuevo objeto Libro con los datos del ViewModelLibro
                var libro = new Libro
                {
                    Titulo = nuevoLibro.Titulo,
                    IdAutor = nuevoLibro.IdAutor,
                    IdGenero = nuevoLibro.IdGenero,
                    PalabrasClave = nuevoLibro.PalabrasClave,
                    Sinopsis = nuevoLibro.Sinopsis
                };

                // Intentar agregar el nuevo libro utilizando el servicio
                bool registroExitoso = await _ser.AgregarLibro(libro);

                if (registroExitoso)
                {
                    // Redirigir a la acción Index si el registro fue exitoso
                    return RedirectToAction("Index");
                }
                else
                {
                    // Mostrar un mensaje de error si hubo algún problema al agregar el libro
                    ModelState.AddModelError(string.Empty, "Hubo un error al agregar el libro.");
                }
            }

            // Si el modelo no es válido, regresar a la vista de AgregarLibro con el ViewModelLibro
            return View(nuevoLibro);
        }



        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
