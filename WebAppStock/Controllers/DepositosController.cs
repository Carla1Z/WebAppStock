using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class DepositosController : Controller
    {
        //public IActionResult Index(int Id)
        //{
        //    DepositoServices depositoServices = new DepositoServices();
        //    var deposito = depositoServices.depositoPorId(Id);
        //    return View(deposito);
        //}  

        public IActionResult Index()
        {
            DepositoServices depositoServices = new DepositoServices();
            var deposito = depositoServices.TodosLosDepositos();
            return View(deposito);
        }
    }
}
