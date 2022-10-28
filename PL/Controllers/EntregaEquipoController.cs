using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class EntregaEquipoController : Controller
    {
        //public ActionResult GetAll()
        //{
        //    ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();

        //    return View(entregaEquipo);

        //}
        public ActionResult Form()
        {
            ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();
            ML.Result result = BL.EntregaEquipo.GetAll();

            ML.Result resultdireccionDestino = BL.DireccionDestino.GetAll();
            entregaEquipo.direccionDestino = new ML.DireccionDestino();
            entregaEquipo.direccionDestino.Direcciones = resultdireccionDestino.Objects.ToList();
           






            if (result.Correct)
            {
                entregaEquipo.Entregas = result.Objects.ToList();

                return View(entregaEquipo);
            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

                return PartialView("Modal");
            }
        }
    }
}


