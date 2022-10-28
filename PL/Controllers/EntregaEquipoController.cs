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
        public ActionResult Form(int? IdEntregaEquipo)
        {
            ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();

            return View(entregaEquipo);
        }
    }
}

