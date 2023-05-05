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

		[HttpDelete]
		public IActionResult Delete(int Id)
		{
			ArticuloDTO eliminarArticulo = services.EliminarArticulo(Id);
			return Ok(eliminarArticulo);
		}

		[HttpPost]
		[Route("{Id}")]
		public IActionResult Edit(ArticuloDTO Id)
		{
			ArticuloDTO editar = services.ModificarArticulo(Id);
			return Ok(editar);
		}

		[HttpGet]
		public IActionResult Get()
		{
			List<ArticuloDTO> articuloDTOs = services.TodosLosArticulos();
			return Ok(articuloDTOs);
		}


		[HttpGet]
		[Route("{Id}")]
		public IActionResult Get(int Id)
		{
			ArticuloDTO articuloDTO = services.ArticuloPorId(Id);
			return Ok(articuloDTO);
		}
	}
}
