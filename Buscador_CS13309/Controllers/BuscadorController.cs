using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Buscador_CS13309.Controllers
{
    public class BuscadorController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome(string name = "SIN NOMBRE", int ID = 0)
        {
            return HtmlEncoder.Default.Encode($"Hola {name}, ID: {ID}");
        }
    }
}
