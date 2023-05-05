using CodigoComun.Modelos.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiStock.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepositosController : ControllerBase
	{
		private DepositoServices services = new DepositoServices();

		[HttpPost]
		public IActionResult Post(DepositoDTO depositoDTO)
		{
			DepositoServices services = new DepositoServices();
			depositoDTO = services.AgregarDeposito(depositoDTO);
			return Ok(depositoDTO);
		}

		[HttpDelete]
		public IActionResult Delete(int Id)
		{
			DepositoDTO eliminarDeposito = services.EliminarDepositoSeleccionado(Id);
			return Ok(eliminarDeposito);
		}

		[HttpPost]
		[Route("{Id}")]
		public IActionResult Edit(DepositoDTO Id)
		{
			DepositoDTO editar = services.ModificarDeposito(Id);
			return Ok(editar);
		}

		[HttpGet]
		public IActionResult Get()
		{
			List<DepositoDTO> depositoDTOs = services.TodosLosDepositos();
			return Ok(depositoDTOs);
		}

		[HttpGet]
		[Route("{Id}")]
		public IActionResult Get(int Id)
		{
			DepositoDTO depositoDTO = services.depositoPorId(Id);

			return Ok(depositoDTO);
		}




	}
}
