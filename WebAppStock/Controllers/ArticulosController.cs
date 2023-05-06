using CodigoComun.Modelos;
using CodigoComun.Modelos.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
	public class ArticulosController : Controller
	{
		private ArticuloServices articuloServices = new ArticuloServices();

		[HttpGet]
		public IActionResult Index()
		{
			var todos = articuloServices.TodosLosArticulos();
			return View(todos);
		}

		public IActionResult Create()
		{
			var articuloACompletar = new ArticuloDTO();
			return View(articuloACompletar);
		}

		[HttpPost]
		public IActionResult Create(ArticuloDTO articuloDTOAGuardar)
		{
			articuloDTOAGuardar = articuloServices.AgregarArticulo(articuloDTOAGuardar);

			if (articuloDTOAGuardar.HuboError == false)
			{
				TempData["Mensaje"] = articuloDTOAGuardar.Mensaje;
				return RedirectToAction("Index");
			}
			else
			{
				TempData["Mensaje"] = articuloDTOAGuardar.Mensaje;
				return View(articuloDTOAGuardar);
			}
		}

		public IActionResult Edit(int Id)
		{
			ArticuloDTO articuloAEditar = articuloServices.ArticuloPorId(Id);
			return View(articuloAEditar);
		}

		[HttpPost]
		public IActionResult Edit(ArticuloDTO articuloAModificar)
		{
			ArticuloDTO editarArticulo = articuloServices.ModificarArticulo(articuloAModificar);

			if (editarArticulo != null)
			{
				TempData["Mensaje"] = editarArticulo.Mensaje;
				return View(articuloAModificar);
			}
			else
			{
				TempData["Mensaje"] = editarArticulo.Mensaje;
				return View(articuloAModificar);
			}
		}


		public IActionResult Delete(int Id)
		{
			ArticuloDTO eliminarArticulo = articuloServices.EliminarArticulo(Id);

			if (eliminarArticulo != null)
			{
				TempData["Mensaje"] = eliminarArticulo.Mensaje;
				return RedirectToAction("Index");
			}
			else
			{
				TempData["Mensaje"] = eliminarArticulo.Mensaje;
				return View();
			}
		}


		public IActionResult Details()
		{
			return View();
		}

	}
}
