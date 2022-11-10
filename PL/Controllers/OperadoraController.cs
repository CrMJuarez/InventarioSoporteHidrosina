using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class OperadoraController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Operadora operadora = new ML.Operadora();
            ML.Result result = BL.Operadora.GetAll();


            if (result.Correct)
            {
                operadora.Operadoras = result.Objects.ToList();
                //return View("PersonalJS");
                return View(operadora);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdOperadora)
        {
            ML.Operadora operadora = new ML.Operadora();


            if (IdOperadora == null)
            {

                return View(operadora);
            }
            else
            {
                ML.Result result = BL.Operadora.GetById(IdOperadora.Value);
                if (result.Correct)
                {
                    operadora = (ML.Operadora)result.Object;
                    return View(operadora);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]

        public ActionResult Form()
        {
            ML.Operadora operadora = new ML.Operadora();


            if (operadora.IdOperadora == null)
            {

                ML.Result result = BL.Operadora.Add(operadora);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente la operadora";
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
                ML.Result result = BL.Operadora.Update(operadora);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente la operadora";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar la operadora";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdOperadora)
        {
            ML.Operadora operadora = new ML.Operadora();
            operadora.IdOperadora = IdOperadora;
            var result = BL.Operadora.Delete(operadora);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente la operadora";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}

