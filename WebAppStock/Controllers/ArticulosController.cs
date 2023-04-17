using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class ArticulosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
