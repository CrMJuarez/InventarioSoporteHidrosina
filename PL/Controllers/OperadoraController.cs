using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;
namespace PL.Controllers
{
    public class OperadoraController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _hostingEnvironment;

        public OperadoraController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Operadora operadora = new ML.Operadora();
           

            ML.Result resultOperadora = new ML.Result();
            resultOperadora.Objects = new List<Object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["WebAPI"]);

                var responseTask = client.GetAsync("api/operadora/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Operadora resultItemlist = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Operadora>(resultItem.ToString());
                        resultOperadora.Objects.Add(resultItemlist);
                    }
                }
                operadora.Operadoras = resultOperadora.Objects;

                return View(operadora);
            }
        }



        [HttpPost]
        public ActionResult GetAll(ML.Operadora operadora)
        {
            ML.Result result = BL.Operadora.GetAll(operadora);

            operadora = new ML.Operadora();

            operadora.Operadoras = result.Objects;

            return View(operadora);
        }


        [HttpGet]
        public ActionResult Form(int? IdOperadora)
        {
            ML.Operadora operadora = new ML.Operadora();
            ML.Result resultPaises = BL.Pais.GetAll();

            operadora.Direccion = new ML.Direccion();
            operadora.Direccion.Colonia = new ML.Colonia();
            operadora.Direccion.Colonia.Municipio = new ML.Municipio();
            operadora.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            operadora.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            if (IdOperadora != null)
            {
                //ML.Result result = BL.Usuario.GetById(IdUsuario.Value);
                ML.Result result = new ML.Result();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["WebAPI"]);
                    var responseTask = client.GetAsync("api/operadora/GetbyId/" + IdOperadora);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Operadora resultItemList = new ML.Operadora();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Operadora>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    if (result.Correct)
                    {
                        operadora = (ML.Operadora)result.Object;
                       

                        ML.Result resultEstados = BL.Estado.GetByIdPais(operadora.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                        ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(operadora.Direccion.Colonia.Municipio.Estado.IdEstado);
                        ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(operadora.Direccion.Colonia.Municipio.IdMunicipio);


                        operadora.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects.ToList();
                        operadora.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects.ToList();
                        operadora.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects.ToList();
                        operadora.Direccion.Colonia.Colonias = resultColonias.Objects.ToList();

                        return View(operadora);
                    }
                    else
                    {
                        ViewBag.Message("Error al realizar la consulta" + result.ErrorMessage);
                        return PartialView("Modal");
                    }
                }
            }
            else
            {
                
                operadora.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects.ToList();
                return View(operadora);
            }
        }







        [HttpPost]

        public ActionResult Form(ML.Operadora operadora)
        {
       
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
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects);
        }

        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects);
        }

        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects);
        }
    }
}

