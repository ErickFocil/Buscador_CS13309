using Buscador_CS13309.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buscador_CS13309.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private BuscarModel buscar = new BuscarModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Resultado(string palabra="uno", bool sSL = false)
        {
            buscar.Palabra = palabra;
            buscar.sSL = sSL;
            List<string> resultado = buscar.Resultado();
            ViewBag.Palabra = palabra;
            ViewBag.Resultado = resultado;

            return View();
        }

        public IActionResult HTMLView(string path)
        {
            ViewBag.Path = path;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}