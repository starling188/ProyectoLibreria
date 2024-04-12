using CapaDatos.DataContext;
using CapaNegocio.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGBL.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SGBL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceLibro _ser;
        private readonly IServiceGenero _serviceGenero;
        private readonly IServiceAutor _serviceAutor;
        private readonly IServicePrestamos _servicePrestamos;

        public HomeController(ILogger<HomeController> logger, IServiceLibro serviceLibro, IServiceGenero serviceGenero, IServiceAutor serviceAutor, IServicePrestamos servicePrestamos)
        {
            _logger = logger;
            _ser = serviceLibro;
            _serviceGenero = serviceGenero;
            _serviceAutor = serviceAutor;
           _servicePrestamos = servicePrestamos;
        }

        public async Task<IActionResult> Index()
        {
            List<Libro> libros = await _ser.ObtenerTodos();
            return View(libros);
        }


        //Buscar
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


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EliminarLibros(int Idlibro)
        {
            bool Eliminarlibro = await _ser.EliminarLibro(Idlibro);

            if (Eliminarlibro)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { error = "Hubo un error al eliminar el libro." });
            }
        }


        [HttpGet]
        public async Task<IActionResult> LibrosRentados()
        {
            // Obtener el nombre de usuario del Claim
            var nombreUsuario = User.Identity.Name;

            // Obtener el ID de usuario utilizando el servicio ServicePrestamos
            int? idUsuario = await _servicePrestamos.ObtenerIdUsuarioPorNombre(nombreUsuario);

            if (idUsuario.HasValue)
            {
                // Obtener los ID de los libros rentados por el usuario con estado "Prestado"
                var idLibrosRentados = await _servicePrestamos.ObtenerIdLibrosRentadosPorUsuario(idUsuario.ToString());

                // Obtener los detalles de los libros rentados utilizando los ID obtenidos
                var librosRentados = new List<RentasViewModel>();
                foreach (var idLibro in idLibrosRentados)
                {
                    // Utilizar el servicio de libros para obtener los detalles del libro por su ID
                    var libro = await _ser.ObtenerPorId(idLibro);
                    if (libro != null)
                    {
                        // Mapear el libro al ViewModel RentasViewModel
                        var rentaViewModel = new RentasViewModel
                        {
                            
                            IdLibro = libro.IdLibro,
                            Titulo = libro.Titulo
                            // Puedes mapear más propiedades si es necesario
                        };
                        librosRentados.Add(rentaViewModel);
                    }
                }

                return View(librosRentados);
            }
            else
            {
                // Manejar el caso en el que no se pueda obtener el ID de usuario
                return RedirectToAction("Index", new { error = "No se pudo obtener el ID de usuario." });
            }
        }


        [HttpPost]
        public async Task<IActionResult> AgregarPrestamo(int idLibro)
        {

            // Obtener el nombre de usuario del Claim
            var nombreUsuario = User.Identity.Name;

            // Obtener el ID de usuario utilizando el servicio ServicePrestamos
            int? idUsuario = await _servicePrestamos.ObtenerIdUsuarioPorNombre(nombreUsuario);

            if (idUsuario.HasValue)
            {
                // Agregar el préstamo del libro para el usuario actual
                bool rentaExitosa = await _servicePrestamos.AgregarPrestamo(idUsuario.Value, idLibro);

                if (rentaExitosa)
                {
                    // Si la renta es exitosa, redirigir a la vista de libros rentados
                    return RedirectToAction("LibrosRentados");
                }
                else
                {
                    // En caso de que falle la renta, puedes manejar el error de alguna manera
                    return RedirectToAction("Index", new { error = "Hubo un error al rentar el libro." });
                }
            }
            else
            {
                // Manejar el caso en el que no se pueda obtener el ID de usuario
                return RedirectToAction("Index", new { error = "No se pudo obtener el ID de usuario." });
            }
        }


        [HttpPost]
        public async Task<IActionResult> DevolverLibro(int idLibro)
        {
            // Obtener el nombre de usuario del Claim
            var nombreUsuario = User.Identity.Name;

            // Obtener el ID de usuario utilizando el servicio ServicePrestamos
            int? idUsuario = await _servicePrestamos.ObtenerIdUsuarioPorNombre(nombreUsuario);

            if (idUsuario.HasValue)
            {
                // Aquí debes agregar la lógica para devolver el libro rentado utilizando el servicio ServicePrestamos
                // Llama al método correspondiente para devolver el préstamo del libro

                // Por ejemplo, podrías llamar a un método llamado DevolverPrestamoPorNombreUsuario
                bool devolucionExitosa = await _servicePrestamos.DevolverPrestamoPorNombreUsuario(nombreUsuario, idLibro);

                if (devolucionExitosa)
                {
                    // Si la devolución es exitosa, redirigir a la vista de libros rentados
                    return RedirectToAction("LibrosRentados");
                }
                else
                {
                    // En caso de que falle la devolución, puedes manejar el error de alguna manera
                    return RedirectToAction("Index", new { error = "Hubo un error al devolver el libro." });
                }
            }
            else
            {
                // Manejar el caso en el que no se pueda obtener el ID de usuario
                return RedirectToAction("Index", new { error = "No se pudo obtener el ID de usuario." });
            }
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
