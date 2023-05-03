using CodigoComun.Entities;
using CodigoComun.Modelos;
using CodigoComun.Modelos.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppStock.ViewModel
{
	public class StockViewModel
	{
		public StockDTO StockDTO { get; set; }
		public List<ArticuloDTO> Articulos { get; set; }
		public List<DepositoDTO> Deposito { get; set; }
		public SelectList selectArticulosList { get; set; }
		public SelectList selectDepositosList { get; set; }

		public StockViewModel()
		{
			StockDTO = new StockDTO();
		}

	}
}
