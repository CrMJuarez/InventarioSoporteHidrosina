using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace PL.Controllers
{
    public class InventarioController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _hostingEnvironment;
        public InventarioController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Inventario inventario = new ML.Inventario();

            ML.Result resultInventario = new ML.Result();
            resultInventario.Objects = new List<Object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["WebAPI"]);

                var responseTask = client.GetAsync("api/inventario/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Inventario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Inventario>(resultItem.ToString());
                        resultInventario.Objects.Add(resultItemList);
                    }
                }

                inventario.Inventarios = resultInventario.Objects;


                return View(inventario);
            }
            
        }
        [HttpPost]
        public ActionResult GetAll(ML.Inventario inventario)
        {

            ML.Result result = BL.Inventario.GetAll(inventario);
            inventario.Inventarios = result.Objects;
            return View(inventario);
        }
        [HttpGet]
        public ActionResult Form(int? IdInventario)
        {
            ML.Inventario inventario = new ML.Inventario();
            ML.Result resultTipoEquipo = BL.TipoEquipo.GetAll();
            ML.Result resultDireccionEntrada = BL.DireccionEntrada.GetAll();
            ML.Result resultMarca = BL.Marca.GetAll();

            inventario.TipoEquipo = new ML.TipoEquipo();
            inventario.DireccionEntrada = new ML.DireccionEntrada();   
            
            inventario.Modelo = new ML.Modelo();
            inventario.Modelo.Marca = new ML.Marca();
            //descomentar en caso de error
           // inventario.Modelo.Marca.Marcas = resultMarca.Objects;

            if (IdInventario != null)
            {
                ML.Result result = new ML.Result();




                //inventario.TipoEquipo = new ML.TipoEquipo();
                //inventario.TipoEquipo.Equipos = resultTipoEquipo.Objects.ToList();
                //inventario.DireccionEntrada = new ML.DireccionEntrada();
                //inventario.DireccionEntrada.Direcciones = resultDireccionEntrada.Objects.ToList();



                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["WebAPI"]);

                    var responseTask = client.GetAsync("api/inventario/GetById/" + IdInventario);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {


                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Inventario resultItemList = new ML.Inventario();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Inventario>(readTask.Result.Object.ToString());

                        result.Object = resultItemList;

                        result.Correct = true;
                    }

                    if (result.Correct)

                    { 

                        inventario= (ML.Inventario)result.Object;



                        inventario.TipoEquipo.Equipos = resultTipoEquipo.Objects.ToList();
                        inventario.DireccionEntrada.Direcciones = resultDireccionEntrada.Objects.ToList();


                        ML.Result resultModelo = BL.Marca.MarcaGetByIdModelo(inventario.Marca.IdMarca.Value);
                        //inventario.Modelo = new ML.Modelo();
                        inventario.Modelo.Marca = new ML.Marca();
                        inventario.Modelo.Marca.Marcas = resultMarca.Objects.ToList();

                        inventario.Modelo.Modelos = resultModelo.Objects.ToList();

                        return View(inventario);

                    }

                    else
                    {
                        ViewBag.Message = "error al traer al inventario"+result.ErrorMessage;
                        return View("Modal");
                    }

                }
            }
            else
            {


                inventario.TipoEquipo = new ML.TipoEquipo();
                inventario.TipoEquipo.Equipos = resultTipoEquipo.Objects.ToList();
                inventario.DireccionEntrada = new ML.DireccionEntrada();
                inventario.DireccionEntrada.Direcciones = resultDireccionEntrada.Objects.ToList();
                inventario.Modelo.Marca.Marcas = resultMarca.Objects.ToList();
                return View(inventario);

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


        public JsonResult DescripcionGetByIdModelo(int IdModelo)
        {
            ML.Result result = BL.Modelo.DescripcionGetByIdModelo(IdModelo);

            return Json(result.Objects);
        }

    }
}
