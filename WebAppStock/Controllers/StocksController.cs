using CodigoComun.Entities;
using CodigoComun.Modelos;
using CodigoComun.Modelos.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppStock.ViewModel;

namespace WebAppStock.Controllers
{
	public class StocksController : Controller
	{
		StockServices stockServices = new StockServices();
		public IActionResult Index()
		{
			var stocks = stockServices.TodosLosStocks();

			// Obtener los nombres de los artículos
			var articulosIds = stocks.Select(s => s.IdArticulo).Distinct().ToList();
			var articuloService = new ArticuloServices();
			var articulos = articulosIds.Select(id => articuloService.ArticuloPorId((int)id));

			// Obtener los nombres de los depósitos
			var depositosIds = stocks.Select(s => s.IdDeposito).Distinct().ToList();
			var depositoService = new DepositoServices();
			var depositos = depositosIds.Select(id => depositoService.depositoPorId((int)id));

			// Agregar los nombres de los artículos y depósitos a cada stock
			foreach (var stock in stocks)
			{
				stock.Articulo = articulos.FirstOrDefault(a => a.Id == stock.IdArticulo);
				stock.Deposito = depositos.FirstOrDefault(d => d.Id == stock.IdDeposito);
			}

			return View(stocks);
		}

		[HttpGet]
		public IActionResult Create()
		{
			StockViewModel stockViewModel = new StockViewModel();
			ArticuloServices articuloServices = new ArticuloServices();
			stockViewModel.Articulos = articuloServices.TodosLosArticulos();

			DepositoServices depositoServices = new DepositoServices();
			stockViewModel.Deposito = depositoServices.TodosLosDepositos();

			stockViewModel.selectArticulosList = new SelectList(stockViewModel.Articulos, "Id", "Nombre");
			stockViewModel.selectDepositosList = new SelectList(stockViewModel.Deposito, "Id", "Nombre");
			stockViewModel.StockDTO = new StockDTO();

			return View(stockViewModel);
		}

		[HttpPost]
		public IActionResult Create(StockViewModel stockViewModel)
		{
			StockDTO stockDTOAAgregar = stockServices.AgregarStock(stockViewModel.StockDTO);
			stockViewModel.StockDTO = stockDTOAAgregar;

			if (stockViewModel.StockDTO.HuboError == false)
			{
				ViewBag.Mensaje = stockViewModel.StockDTO.Mensaje;
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Mensaje = stockViewModel.StockDTO.Mensaje;
				return View(stockViewModel);
			}
		}

		public IActionResult Edit(int Id)
		{
			StockDTO stockDTO = stockServices.stockPorId(Id);

			ArticuloServices articuloServices = new ArticuloServices();
			ArticuloDTO articuloDTO = articuloServices.ArticuloPorId((int)stockDTO.IdArticulo);

			DepositoServices depositoServices = new DepositoServices();
			DepositoDTO depositoDTO = depositoServices.depositoPorId((int)stockDTO.IdDeposito);

			// Nuevo objeto StockViewModel con la información de la base de datos
			StockViewModel stockViewModel = new StockViewModel();
			stockViewModel.StockDTO = stockDTO;
			stockViewModel.Articulos = articuloServices.TodosLosArticulos();
			stockViewModel.Deposito = depositoServices.TodosLosDepositos();
			stockViewModel.selectArticulosList = new SelectList(stockViewModel.Articulos, "Id", "Nombre", articuloDTO.Id);
			stockViewModel.selectDepositosList = new SelectList(stockViewModel.Deposito, "Id", "Nombre", depositoDTO.Id);

			return View(stockViewModel);
		}


		[HttpPost]
		public IActionResult Edit(StockViewModel stockViewModel)
		{
			StockDTO stockAModificar = stockViewModel.StockDTO;
			StockDTO editarStock = stockServices.ModificarStock(stockAModificar);

			if (editarStock != null)
			{
				ViewBag.Mensaje = editarStock.Mensaje;
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Mensaje = editarStock.Mensaje;
				return View(stockViewModel);
			}
		}



		public IActionResult Delete(int Id)
		{
			StockDTO eliminarStock = stockServices.EliminarStockSeleccionado(Id);

			if (eliminarStock != null)
			{
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Mensaje = eliminarStock.Mensaje;
				return View();
			}

		}

	}
}
