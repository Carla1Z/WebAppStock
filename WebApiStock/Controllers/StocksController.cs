using CodigoComun.Entities;
using CodigoComun.Modelos.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiStock.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StocksController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetStocks()
		{
			StockServices services = new StockServices();
			List<StockDTO> stockDTO = services.TodosLosStocks();
			return Ok(stockDTO);
		}

		[HttpGet]
		public IActionResult Get(int Id)
		{
			StockServices services = new StockServices();
			Stock stock = services.stockPorId(Id);
			return Ok(stock);
		}

		[HttpDelete]
		public IActionResult Delete(StockDTO Id)
		{
			StockServices services = new StockServices();
			StockDTO stock = services.EliminarStockSeleccionado(Id);
			return Ok(stock);
		}

		[HttpPost]
		public IActionResult Post(StockDTO stockDTO)
		{
			StockServices services = new StockServices();
			stockDTO = services.AgregarStock(stockDTO);
			return Ok(stockDTO);
		}
	}
}
