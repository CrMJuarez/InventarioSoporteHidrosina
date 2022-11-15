using Microsoft.AspNetCore.Mvc;
using ML;
using System.Linq;

namespace PL.Controllers
{
    public class EntregaEquipoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();
            ML.Result result = BL.EntregaEquipo.GetAll();


            if (result.Correct)
            {
                entregaEquipo.Entregas = result.Objects.ToList();
                //return View("PersonalJS");
                return View(entregaEquipo);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView(entregaEquipo);
        }

        [HttpGet]
        public ActionResult Form()
        {
            ML.Inventario inventario = new ML.Inventario();
            ML.Operadora operadora = new ML.Operadora();
            ML.Result result = BL.EntregaEquipo.GetAll();
            ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();
            ML.Result resultDestino = BL.DireccionDestino.GetAll();
            ML.Result resultPersonalEntrega = BL.PersonalEntrega.GetAll();
            ML.Result resultPersonalAutorizacion = BL.PersonalAutorizacion.GetAll();
            ML.Result resultOperadora = BL.Operadora.GetAll(operadora);
            ML.Result resultInventario = BL.Inventario.GetAll(inventario);

            if (resultDestino.Correct)
            {
                entregaEquipo.direccionDestino = new ML.DireccionDestino();
                entregaEquipo.direccionDestino.Direcciones = resultDestino.Objects.ToList();
                entregaEquipo.personalEntrega = new ML.PersonalEntrega();
                entregaEquipo.personalEntrega.Personales = resultPersonalEntrega.Objects.ToList();
                entregaEquipo.personalAutorizacion = new ML.PersonalAutorizacion();
                entregaEquipo.personalAutorizacion.Personales = resultPersonalAutorizacion.Objects.ToList();
                entregaEquipo.operadora = new ML.Operadora();
                entregaEquipo.operadora.Operadoras = resultOperadora.Objects.ToList();
                entregaEquipo.inventario = new ML.Inventario();
                entregaEquipo.inventario.Inventarios = resultInventario.Objects.ToList();
                
                return View(entregaEquipo);
            }
            else
            {
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;

                return PartialView("Modal");
            }
        }
        [HttpPost]
        public ActionResult Form(ML.EntregaEquipo entregaEquipo)
        {

            if (entregaEquipo.IdEntregaEquipo == null)
            {
                ML.Result result = BL.EntregaEquipo.Add(entregaEquipo);
                if (result.Correct)
                {
                    ViewBag.Message = "Equipo entregado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }                       
                return PartialView(entregaEquipo);         
        }
    }
}



