using CodigoComun.Modelos;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class StocksController : Controller
    {
        public IActionResult Index()
        {
            StockServices stockServices = new StockServices();
            var stocks = stockServices.TodosLosStocks();

            return View(stocks);
        }


    }
}
