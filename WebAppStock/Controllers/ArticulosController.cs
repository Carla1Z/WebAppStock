using CodigoComun.Modelos;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
	public class ArticulosController : Controller
	{
		private ArticuloServices articuloServices = new ArticuloServices();
		private Articulo articulo = new Articulo();

		[HttpGet]
		public IActionResult Index()
		{
			var todos = articulo.GetTodosLosArticulos();
			return View(todos);
		}

		public IActionResult Create()
		{
			var articuloACompletar = new Articulo();
			return View(articuloACompletar);
		}

		[HttpPost]
		public IActionResult Create(Articulo articuloAGuardar)
		{
			string mensaje = articuloServices.AgregarArticulo(articuloAGuardar);

			if (mensaje == "Articulo Agregado")
			{
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Mensaje = mensaje;
				return View(articuloAGuardar);
			}
		}

		public IActionResult Edit(int Id)
		{
			var articuloAEditar = articulo.GetArticuloPorId(Id);
			return View(articuloAEditar);
		}

		[HttpPost]
		public IActionResult Edit(Articulo articuloAModificar)
		{
			string mensaje = articuloServices.ModificarArticulo(articuloAModificar);

			if (mensaje == "Articulo Modificado")
			{
				ViewBag.Mensaje = mensaje;
				return View(articuloAModificar);
			}
			else
			{
				ViewBag.Mensaje = mensaje;
				return View(articuloAModificar);
			}
		}


		public IActionResult Delete(int Id)
		{
			string mensaje = articuloServices.EliminarArticulo(Id);

			if (mensaje == "Articulo eliminado")
			{
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Mensaje = mensaje;
				return View();
			}
		}


		public IActionResult Details()
		{
			return View();
		}

	}
}
