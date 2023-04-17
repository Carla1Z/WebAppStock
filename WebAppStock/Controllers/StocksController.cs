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

            // Obtener los nombres de los artículos
            var articulosIds = stocks.Select(s => s.IdArticulo).Distinct().ToList();
            var articuloService = new Articulo();
            var articulos = articulosIds.Select(id => articuloService.GetArticuloPorId((int)id));

            // Obtener los nombres de los depósitos
            var depositosIds = stocks.Select(s => s.IdDeposito).Distinct().ToList();
            var depositoService = new DepositoServices();
            var depositos = depositosIds.Select(id => depositoService.depositoPorId((int)id));

            // Agregar los nombres de los artículos y depósitos a cada stock
            foreach (var stock in stocks)
            {
                stock.Articulos = articulos.FirstOrDefault(a => a.Id == stock.IdArticulo);
                stock.IdDepositoNavigation = depositos.FirstOrDefault(d => d.Id == stock.IdDeposito);
            }

            return View(stocks);
        }


    }
}
