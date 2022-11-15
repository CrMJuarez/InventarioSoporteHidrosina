using BL;
using Microsoft.AspNetCore.Mvc;
using ML;
using System.Linq;

namespace PL.Controllers
{
    public class DireccionDestinoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.DireccionDestino direccionDestino = new ML.DireccionDestino();
            ML.Result result = BL.DireccionDestino.GetAll();

            if (result.Correct)
            {
                direccionDestino.Direcciones = result.Objects.ToList();
                //return View("PersonalJS");
                return View(direccionDestino);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdDireccionDestino)
        {
            ML.DireccionDestino direccionDestino = new ML.DireccionDestino();
            ML.Operadora operadora = new ML.Operadora();
            ML.Result resultOperadora = BL.Operadora.GetAll(operadora);
            direccionDestino.Operadora = new ML.Operadora();

            if (IdDireccionDestino == null)
            {
                direccionDestino.Operadora = new ML.Operadora();
                direccionDestino.Operadora.Operadoras = resultOperadora.Objects.ToList();
                return View(direccionDestino);
            }
            else
            {
                ML.Result result = BL.DireccionDestino.GetById(IdDireccionDestino.Value);
                if (result.Correct)
                {
                    direccionDestino = (ML.DireccionDestino)result.Object;
                    direccionDestino.Operadora.Operadoras = resultOperadora.Objects.ToList();

                    return View(direccionDestino);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]

        public ActionResult Form(ML.DireccionDestino direccionDestino)
        {
            if (direccionDestino.IdDireccionDestino == null)
            {

                ML.Result result = BL.DireccionDestino.Add(direccionDestino);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente la direccion de destino";
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
                ML.Result result = BL.DireccionDestino.Update(direccionDestino);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente la direccion de destino";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar la direccion de destino";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdDireccionDestino)
        {
            ML.DireccionDestino direccionDestino = new ML.DireccionDestino();
            direccionDestino.IdDireccionDestino = IdDireccionDestino;
            var result = BL.DireccionDestino.Delete(direccionDestino);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente la direccion de destino";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}

