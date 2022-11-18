using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL_1.Controllers
{
    [Authorize]
    public class TipoEquipoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.TipoEquipo tipoEquipo = new ML.TipoEquipo();
            ML.Result result = BL.TipoEquipo.GetAll();


            if (result.Correct)
            {
                tipoEquipo.Equipos = result.Objects.ToList();
                //return View("PersonalJS");
                return View(tipoEquipo);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdTipoEquipo)
        {
            ML.TipoEquipo tipoEquipo = new ML.TipoEquipo();


            if (IdTipoEquipo == null)
            {

                return View(tipoEquipo);
            }
            else
            {
                ML.Result result = BL.TipoEquipo.GetById(IdTipoEquipo.Value);
                if (result.Correct)
                {
                    tipoEquipo = (ML.TipoEquipo)result.Object;
                    return View(tipoEquipo);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]

        public ActionResult Form(ML.TipoEquipo tipoEquipo)
        {
            if (tipoEquipo.IdTipoEquipo == null)
            {

                ML.Result result = BL.TipoEquipo.Add(tipoEquipo);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente el tipo de equipo";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = BL.TipoEquipo.Update(tipoEquipo);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el tipo de equipo";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar el tipo de equipo";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdTipoEquipo)
        {
            ML.TipoEquipo tipoEquipo = new ML.TipoEquipo();
            tipoEquipo.IdTipoEquipo = IdTipoEquipo;
            var result = BL.TipoEquipo.Delete(tipoEquipo);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente el tipo de equipo";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}

