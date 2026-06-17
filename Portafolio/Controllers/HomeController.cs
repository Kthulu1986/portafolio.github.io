using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        //private readonly ServicioTransitorio servicioTransitorio;
        //private readonly ServicioDelimitado servicioDelimitado;
        //private readonly ServicioUnico servicioUnico;

        public HomeController(ILogger<HomeController> logger, 
            IRepositorioProyectos repositorioProyectos, 
            IServicioEmail servicioEmail)
            //ServicioTransitorio servicioTransitorio, 
            //ServicioDelimitado servicioDelimitado, 
            //ServicioUnico servicioUnico )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
            //this.servicioTransitorio = servicioTransitorio;
            //this.servicioDelimitado = servicioDelimitado;
            //this.servicioUnico = servicioUnico;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Este es un mensaje de ilogger");
            var proyectos = repositorioProyectos.obtenerProyectos().Take(3).ToList();

            //var ejemploViewModel = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado.ObtenerGuid,
            //    Unico = servicioUnico.ObtenerGuid,
            //    Transitorio = servicioTransitorio.ObtenerGuid
            //};
            var modelo = new HomeIndexDTO() { 
                Proyectos = proyectos,
                //EjemploGUID_1 = ejemploViewModel
            };
            ////ViewBag.Nombre = "Nelson Huenchuleo Valdivia";
            //var persona = new Persona()
            //{
            //    Nombre = "Nelsito",
            //    Edad = .
            //};
            //ViewBag.Edad = 35;
            //return View("Index","Sebastian Huenchuleo");
            return View(modelo);
        }        
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.obtenerProyectos();
            return View(proyectos);
        }
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }
        //atributo para determinar que estamos realizando una peticion http post y vamos a recibir del servidor una respuesta http
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoDTO contactoDto)
        {
            await servicioEmail.Enviar(contactoDto);
            return RedirectToAction("Gracias","Home", contactoDto);
        }
        public IActionResult Gracias(ContactoDTO contactoDto)
        {
            //var cliente = new ClienteDTO()
            //{
            //    Nombre="Nelson",
            //    Email="nelson@gmail.com",
            //    Comentario="coordinemos una reunión"
            //};
            return View(contactoDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}