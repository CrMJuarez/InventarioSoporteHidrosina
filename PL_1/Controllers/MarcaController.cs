using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL_1.Controllers
{
    [Authorize]
    public class MarcaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Marca marca = new ML.Marca();

            ML.Result result = BL.Marca.GetAll();

            if (result.Correct)
            {
                marca.Marcas = result.Objects.ToList();

                return View(marca);
            }
            else

                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdMarca)
        {
            ML.Marca marca = new ML.Marca();

            if (IdMarca == null)
            {

                return View(marca);
            }
            else
            {
                ML.Result result = BL.Marca.GetById(IdMarca.Value);

                if (result.Correct)
                {
                    marca = (ML.Marca)result.Object;

                    return View(marca);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;

                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Marca marca)
        {
            if (marca.IdMarca == null)
            {

                ML.Result result = BL.Marca.Add(marca);

                if (result.Correct)

                {
                    ViewBag.Message = "Se agrego correctamente la marca";

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
                ML.Result result = BL.Marca.Update(marca);

                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente la marca";

                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar la marca";

                    return PartialView("Modal");

                }
            }
        }
        [HttpGet]
        public ActionResult Delete(int IdMarca)
        {
            ML.Marca marca = new ML.Marca();

            marca.IdMarca = IdMarca;

            var result = BL.Marca.Delete(marca);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente la marca";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }
    }
}
