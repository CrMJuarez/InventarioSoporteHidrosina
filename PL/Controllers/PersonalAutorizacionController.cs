using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class PersonalAutorizacionController : Controller
    {
      

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.PersonalAutorizacion personalAutorizacion = new ML.PersonalAutorizacion();
            ML.Result result = BL.PersonalAutorizacion.GetAll();
            

            if (result.Correct)
            {
                personalAutorizacion.Personales = result.Objects.ToList();
                //return View("PersonalJS");
                return View(personalAutorizacion);
                  }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdPersonalAutorizacion)
        {
            ML.PersonalAutorizacion personal = new ML.PersonalAutorizacion();


            if (IdPersonalAutorizacion == null)
            {

                return View(personal);
            }
            else
            {
                ML.Result result = BL.PersonalAutorizacion.GetById(IdPersonalAutorizacion.Value);
                if (result.Correct)
                {
                    personal = (ML.PersonalAutorizacion)result.Object;
                    return View(personal);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]

        public ActionResult Form(ML.PersonalAutorizacion personal)
        {
            if (personal.IdPersonalAutorizacion == null)
            {

                ML.Result result = BL.PersonalAutorizacion.Add(personal);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente el personal de autorizacion";
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
                ML.Result result = BL.PersonalAutorizacion.Update(personal);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el personal de autorizacion";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar el personal de autorizacion";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdPersonalAutorizacion)
        {
            ML.PersonalAutorizacion personal = new ML.PersonalAutorizacion();
            personal.IdPersonalAutorizacion = IdPersonalAutorizacion;
            var result = BL.PersonalAutorizacion.Delete(personal);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente el personal de autorizacion";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}