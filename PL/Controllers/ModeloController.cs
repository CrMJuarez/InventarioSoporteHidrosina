using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class ModeloController : Controller
    {
         
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Modelo modelo = new ML.Modelo();
            ML.Result result = BL.Modelo.GetAll();


            if (result.Correct)
            {
                modelo.Modelos = result.Objects.ToList();
                //return View("PersonalJS");
                return View(modelo);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdModelo)
        {
            ML.Modelo modelo = new ML.Modelo();
            ML.Result resultmarca = BL.Marca.GetAll();
            modelo.Marca = new ML.Marca();

            if (IdModelo == null)
            {
                modelo.Marca = new ML.Marca();
                modelo.Marca.Marcas = resultmarca.Objects.ToList();
                return View(modelo);
            }
            else
            {
                ML.Result result = BL.Modelo.GetById(IdModelo.Value);
                if (result.Correct)
                {
                    modelo = (ML.Modelo)result.Object;
                    modelo.Marca.Marcas = resultmarca.Objects.ToList();
                    
                    return View(modelo);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]

        public ActionResult Form(ML.Modelo modelo)
        {
            if (modelo.IdModelo == null)
            {

                ML.Result result = BL.Modelo.Add(modelo);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente el modelo";
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
                ML.Result result = BL.Modelo.Update(modelo);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el modelo";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar el modelo";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdModelo)
        {
            ML.Modelo modelo = new ML.Modelo();
            modelo.IdModelo = IdModelo;
            var result = BL.Modelo.Delete(modelo);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente el modelo";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}
