using CodigoComun.Entities;
using CodigoComun.Modelos.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class DepositosController : Controller
    {
        private DepositoServices depositoServices = new DepositoServices();

		public IActionResult Index()
        {
            var deposito = depositoServices.TodosLosDepositos();
            return View(deposito);
        }

        public IActionResult Create()
        {
            var depositoACompletar = new DepositoDTO();
            return View(depositoACompletar);
        }
        [HttpPost]
        public IActionResult Create(DepositoDTO depositoDTOAAgregar)
        {
			depositoDTOAAgregar = depositoServices.AgregarDeposito(depositoDTOAAgregar);

            if (depositoDTOAAgregar.HuboError == false)
            {
                ViewBag.Mensaje = depositoDTOAAgregar.Mensaje;
				return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = depositoDTOAAgregar.Mensaje;
                return View(depositoDTOAAgregar);
            }
        }

        public IActionResult Edit(int Id)
        {
            DepositoDTO depositoAEditar = depositoServices.depositoPorId(Id);
            return View(depositoAEditar);
        }

        [HttpPost]
        public IActionResult Edit(DepositoDTO depositoAModificar)
        {
            DepositoDTO editarDeposito = depositoServices.ModificarDeposito(depositoAModificar);

            if (editarDeposito != null)
            {
                ViewBag.Mensaje = editarDeposito.Mensaje;
                return View(depositoAModificar);
            }
            else
            {
                ViewBag.Mensaje = editarDeposito.Mensaje;
                return View(depositoAModificar);
            }
        }

        public IActionResult Delete(int Id)
        {
            DepositoDTO eliminarDeposito = depositoServices.EliminarDepositoSeleccionado(Id);

            if (eliminarDeposito != null)
            {
				TempData["Mensaje"] = eliminarDeposito.Mensaje;
				return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = eliminarDeposito.Mensaje;
                return View();
            }
        }

    }
}
