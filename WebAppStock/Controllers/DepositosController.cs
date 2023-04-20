using CodigoComun.Entities;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class DepositosController : Controller
    {
        private DepositoServices depositoServices = new DepositoServices();

		//public IActionResult Index(int Id)
		//{
		//    DepositoServices depositoServices = new DepositoServices();
		//    var deposito = depositoServices.depositoPorId(Id);
		//    return View(deposito);
		//}  

		public IActionResult Index()
        {
            var deposito = depositoServices.TodosLosDepositos();
            return View(deposito);
        }

        public IActionResult Create()
        {
            var depositoACompletar = new Deposito();
            return View(depositoACompletar);
        }

        [HttpPost]
        public IActionResult Create(Deposito depositoAAgregar)
        {
            string mensaje = depositoServices.AgregarDeposito(depositoAAgregar);

            if (mensaje == "Deposito Agregado")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = mensaje;
                return View(depositoAAgregar);
            }
        }

        public IActionResult Edit(int Id)
        {
            var depositoAEditar = depositoServices.depositoPorId(Id);
            return View(depositoAEditar);
        }

        [HttpPost]
        public IActionResult Edit(Deposito depositoAModificar)
        {
            string mensaje = depositoServices.ModificarDeposito(depositoAModificar);

            if (mensaje == "Deposito Modificado")
            {
                ViewBag.Mensaje = mensaje;
                return View(depositoAModificar);
            }
            else
            {
                ViewBag.Mensaje = mensaje;
                return View(depositoAModificar);
            }
        }

        public IActionResult Delete(int Id)
        {
            string mensaje = depositoServices.EliminarDepositoSeleccionado(Id);

            if (mensaje == "Deposito eliminado")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = mensaje;
                return View();
            }
        }

    }
}
