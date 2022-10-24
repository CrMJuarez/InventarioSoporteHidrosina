using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class PersonalEntregaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.PersonalEntrega personalEntrega = new ML.PersonalEntrega();
            ML.Result result = BL.PersonalEntrega.GetAll();


            if (result.Correct)
            {
                personalEntrega.Personales = result.Objects.ToList();
                //return View("PersonalJS");
                return View(personalEntrega);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdPersonalEntrega)
        {
            ML.PersonalEntrega personal = new ML.PersonalEntrega();
      
  
            if (IdPersonalEntrega == null)
            {
                
                return View(personal);
            }
            else
            {
                ML.Result result = BL.PersonalEntrega.GetById(IdPersonalEntrega.Value);
                if (result.Correct)
                {
                    personal = (ML.PersonalEntrega)result.Object;
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

        public ActionResult Form(ML.PersonalEntrega personal)
        {
            if (personal.IdPersonalEntrega == null)
            {

                ML.Result result = BL.PersonalEntrega.Add(personal);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente el personal de entrega";
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
                ML.Result result = BL.PersonalEntrega.Update(personal);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el personal de entrega";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar el personal de entrega";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdPersonalEntrega)
        {
            ML.PersonalEntrega personal = new ML.PersonalEntrega();
            personal.IdPersonalEntrega = IdPersonalEntrega;
            var result = BL.PersonalEntrega.Delete(personal);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente el personal de entrega";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}
