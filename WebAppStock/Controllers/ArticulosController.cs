using CodigoComun.Modelos;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class ArticulosController : Controller
    {
        public IActionResult Index()
        {
            Articulo articulo = new Articulo();
            var todos = articulo.GetTodosLosArticulos();
            return View(todos);
        }
    }
}
