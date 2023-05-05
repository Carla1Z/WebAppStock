using CodigoComun.Modelos.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiStock.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticulosController : ControllerBase
	{
		private ArticuloServices services = new ArticuloServices();

		[HttpPost]
		public IActionResult Post(ArticuloDTO articuloDTO)
		{
			articuloDTO = services.AgregarArticulo(articuloDTO);
			return Ok(articuloDTO);
		}
	}
}
