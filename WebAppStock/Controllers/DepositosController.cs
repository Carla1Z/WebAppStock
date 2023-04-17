using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class DepositosController : Controller
    {
        public IActionResult Index()
        {
            DepositoServices depositoServices = new DepositoServices();
            var deposito = depositoServices.depositoPorId(1);
            return View(deposito);
        }
    }
}
