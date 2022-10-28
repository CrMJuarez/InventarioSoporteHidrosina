using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace PL.Controllers
{
    public class InventarioController : Controller
    {
     
        public ActionResult GetAll()
        {
            ML.Inventario inventario = new ML.Inventario();
            ML.Result result = BL.Inventario.GetAll();
            //ML.Result resultRol = BL.Rol.GetAll();
            // usuario.Rol = new ML.Rol();

            if (result.Correct)
            {
                inventario.Inventarios = result.Objects.ToList();
                return View(inventario);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdInventario)
        {
            ML.Inventario inventario = new ML.Inventario();

            ML.Result resultTipoEquipo = BL.TipoEquipo.GetAll();
            inventario.TipoEquipo = new ML.TipoEquipo();
            //ML.Result resultModelos = BL.Modelo.GetAll()         

            ML.Result resultDireccionEntrada = BL.DireccionEntrada.GetAll();
            inventario.DireccionEntrada = new ML.DireccionEntrada();
            ML.Result resultMarca = BL.Marca.GetAll();
            inventario.Modelo = new ML.Modelo();

            inventario.Modelo.Marca = new ML.Marca();

            //inventario.Modelo.Modelos = resultModelos.Objects.ToList();
            inventario.Modelo.Marca.Marcas = resultMarca.Objects;


           
            if (IdInventario == null)
            {

                inventario.TipoEquipo = new ML.TipoEquipo();
                inventario.TipoEquipo.Equipos = resultTipoEquipo.Objects.ToList();
                inventario.DireccionEntrada = new ML.DireccionEntrada();
                inventario.DireccionEntrada.Direcciones = resultDireccionEntrada.Objects.ToList();

                return View(inventario);
            }
            else
            {
                

                ML.Result result = BL.Inventario.GetById(IdInventario.Value);

         
                
                if (result.Correct)
                {


                   

                    
                    inventario = ((ML.Inventario)result.Object);

                    inventario.Modelo = new ML.Modelo();
                    inventario.Modelo.Marca = new ML.Marca();


                    ML.Result resultModelo = BL.Marca.MarcaGetByIdModelo(inventario.Marca.IdMarca.Value);



                    inventario.Modelo.Marca.Marcas = resultMarca.Objects.ToList();
                    
                    inventario.Modelo.Modelos = resultModelo.Objects.ToList();

                    inventario.TipoEquipo.Equipos = resultTipoEquipo.Objects.ToList();

                    inventario.DireccionEntrada.Direcciones = resultDireccionEntrada.Objects.ToList();

                    return View(inventario);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]

        public ActionResult Form(ML.Inventario inventario)
        {
            if (inventario.IdInventario == null)
            {

                ML.Result result = BL.Inventario.Add(inventario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente el equipo a inventario";
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
                ML.Result result = BL.Inventario.Update(inventario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el equipo a inventario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo actualizar el equipo a inventario";
                    return PartialView("Modal");

                }
            }

        }
        [HttpGet]
        public ActionResult Delete(int IdInventario)
        {
            ML.Inventario inventario = new ML.Inventario();
            inventario.IdInventario = IdInventario;
            var result = BL.Inventario.Delete(inventario);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente el equipo";

            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

            }

            return PartialView("Modal");


        }

        public JsonResult MarcaGetByIdModelo(int IdMarca)
        {
            ML.Result result = BL.Marca.MarcaGetByIdModelo(IdMarca);

            return Json(result.Objects);
        }
    }
}
