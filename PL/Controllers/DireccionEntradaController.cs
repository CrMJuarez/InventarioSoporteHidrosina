using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class DireccionEntradaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
            ML.Result result = BL.DireccionEntrada.GetAll();


            if (result.Correct)
            {
                direccionEntrada.Direcciones = result.Objects.ToList();
                //return View("PersonalJS");
                return View(direccionEntrada);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdDireccionEntrada)
        {
            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
            ML.Result resultOperadora = BL.Operadora.GetAll();
            direccionEntrada.Operadora = new ML.Operadora();

            if (IdDireccionEntrada == null)
            {
                direccionEntrada.Operadora = new ML.Operadora();
                direccionEntrada.Operadora.Operadoras = resultOperadora.Objects.ToList();
                return View(direccionEntrada);
            }
            else
            {
                ML.Result result = BL.DireccionEntrada.GetById(IdDireccionEntrada.Value);
                if (result.Correct)
                {
                    direccionEntrada = (ML.DireccionEntrada)result.Object;
                    direccionEntrada.Operadora.Operadoras = resultOperadora.Objects.ToList();

                    return View(direccionEntrada);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]

        public ActionResult Form(ML.DireccionEntrada direccionEntrada)
        {
            if (direccionEntrada.IdDireccionEntrada == null)
            {

                ML.Result result = BL.DireccionEntrada.Add(direccionEntrada);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente la direccion de entrada";
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
                ML.Result result = BL.DireccionEntrada.Update(direccionEntrada);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente la direccion de entrada";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar la direccion de entrada";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdDireccionEntrada)
        {
            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
            direccionEntrada.IdDireccionEntrada = IdDireccionEntrada;
            var result = BL.DireccionEntrada.Delete(direccionEntrada);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente la direccion de entrada";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}

