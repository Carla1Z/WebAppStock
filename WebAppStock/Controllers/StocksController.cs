using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class StocksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
