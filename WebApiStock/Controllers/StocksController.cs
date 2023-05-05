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

		private StockServices services = new StockServices();

		[HttpPost]
		public IActionResult Post(StockDTO stockDTO)
		{
			stockDTO = services.AgregarStock(stockDTO);
			return Ok(stockDTO);
		}

		[HttpDelete]
		public IActionResult Delete(int Id)
		{
			StockDTO eliminarStock = services.EliminarStockSeleccionado(Id);
			return Ok(eliminarStock);
		}

		[HttpPost]
		[Route("{Id}")]
		public IActionResult Edit(StockDTO Id)
		{
			StockDTO editar = services.ModificarStock(Id);
			return Ok(editar);
		}

		[HttpGet]
		public IActionResult GetStocks()
		{
			List<StockDTO> stockDTOs = services.TodosLosStocks();
			return Ok(stockDTOs);
		}

		[HttpGet]
		[Route("{Id}")]
		public IActionResult Get(int Id)
		{
			StockDTO stockDTOs = services.stockPorId(Id);
			return Ok(stockDTOs);
		}


	}
}
