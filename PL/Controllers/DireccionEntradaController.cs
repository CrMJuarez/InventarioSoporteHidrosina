using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Net.Http;

namespace PL.Controllers
{
    public class DireccionEntradaController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _hostingEnvironment;

        public DireccionEntradaController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
            ML.Result resultDireccionEntrada = new ML.Result();
            resultDireccionEntrada.Objects = new List<Object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["WebAPI"]);

                var responseTask = client.GetAsync("api/direccionEntrada/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.DireccionEntrada resultItemlist = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.DireccionEntrada>(resultItem.ToString());
                        resultDireccionEntrada.Objects.Add(resultItemlist);
                    }
                }
                direccionEntrada.Direcciones = resultDireccionEntrada.Objects;

                return View(direccionEntrada);
            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.DireccionEntrada direccionEntrada)
        {
            ML.Result result = BL.DireccionEntrada.GetAll(direccionEntrada);

            direccionEntrada = new ML.DireccionEntrada();

            direccionEntrada.Direcciones = result.Objects;

            return View(direccionEntrada);
        }

        [HttpGet]
        public ActionResult Form(int? IdDireccionEntrada)
        {
            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
            ML.Operadora operadora = new ML.Operadora();
            ML.Result resultOperadora = BL.Operadora.GetAll(operadora);
            direccionEntrada.Operadora = new ML.Operadora();
            ML.Result resultPaises = BL.Pais.GetAll();

            direccionEntrada.Direccion = new ML.Direccion();
            direccionEntrada.Direccion.Colonia = new ML.Colonia();
            direccionEntrada.Direccion.Colonia.Municipio = new ML.Municipio();
            direccionEntrada.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();


            if (IdDireccionEntrada != null)
            {
                ML.Result result = new ML.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["WebAPI"]);
                    var responseTask = client.GetAsync("api/direccionEntrada/GetbyId/" + IdDireccionEntrada);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.DireccionEntrada resultItemList = new ML.DireccionEntrada();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.DireccionEntrada>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    if (result.Correct)
                    {

                        direccionEntrada = (ML.DireccionEntrada)result.Object;
                        direccionEntrada.Operadora.Operadoras = resultOperadora.Objects.ToList();
                        ML.Result resultEstados = BL.Estado.GetByIdPais(direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                        ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(direccionEntrada.Direccion.Colonia.Municipio.Estado.IdEstado);
                        ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(direccionEntrada.Direccion.Colonia.Municipio.IdMunicipio);


                        direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects.ToList();
                        direccionEntrada.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects.ToList();
                        direccionEntrada.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects.ToList();
                        direccionEntrada.Direccion.Colonia.Colonias = resultColonias.Objects.ToList();

                        return View(direccionEntrada);
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
                direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects.ToList();

                direccionEntrada.Operadora = new ML.Operadora();
                direccionEntrada.Operadora.Operadoras = resultOperadora.Objects.ToList();
                return View(direccionEntrada);
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

