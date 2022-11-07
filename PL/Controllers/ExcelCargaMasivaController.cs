using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System;
using IWebHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;
using Microsoft.AspNetCore.Hosting;

namespace PL.Controllers
{
    public class ExcelCargaMasivaController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ExcelCargaMasivaController(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult EmpleadoCargaMasiva()
        {
            ML.Result result = new ML.Result();
            return View(result);
        }
        //[HttpPost]
        //public ActionResult EmpleadoCargaMasiva(ML.EntregaEquipo entregaEquipo)
        //{
        //    IFormFile archivo = Request.Form.Files["FileExcel"];
        //    if (HttpContext.Session.GetString("PathArchivo") == null)
        //    {
        //        if (archivo.Length > 0)
        //        {
        //            string fileName = Path.GetFileName(archivo.FileName);
        //            string folderPath = _configuration["PathFolder:value"];
        //            string extensionArchivo = Path.GetExtension(archivo.FileName).ToLower();
        //            string extensionModulo = _configuration["TipoExcel"];

        //            if (extensionArchivo == extensionModulo)
        //            {
        //                string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, folderPath, Path.GetFileNameWithoutExtension(fileName)) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
        //                if (!System.IO.File.Exists(filePath))
        //                {
        //                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
        //                    {
        //                        archivo.CopyTo(stream);
        //                    }
        //                    string connectionString = _configuration["ConnectionStringExcel:value"] + filePath;
        //                    ML.Result resultEmpleados = BL.EntregaEquipo.ConvertirExceltoDataTable(connectionString);
        //                    if (resultEmpleados.Correct)
        //                    {
        //                        ML.Result resultValidacion = BL.EntregaEquipo.ValidarExcel(resultEmpleados.Objects);
        //                        if (resultValidacion.Objects.Count == 0)
        //                        {
        //                            resultValidacion.Correct = true;
        //                            HttpContext.Session.SetString("PathArchivo", filePath);
        //                        }

        //                        return View(resultValidacion);
        //                    }
        //                    else
        //                    {
        //                        ViewBag.Message = "El excel no contiene registros";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ViewBag.Message = "Favor de seleccionar un archivo .xlsx, Verifique su archivo";
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = "No selecciono ningun archivo, Seleccione uno correctamente";
        //        }
        //    }
        //    else
        //    {
        //        string rutaArchivoExcel = HttpContext.Session.GetString("PathArchivo");
        //        string connectionString = _configuration["ConnectionStringExcel:value"] + rutaArchivoExcel;
        //        ML.Result resultData = BL.EntregaEquipo.ConvertirExceltoDataTable(connectionString);
        //        if (resultData.Correct)
        //        {
        //            ML.Result resultErrores = new ML.Result();
        //            resultErrores.Objects = new List<object>();

        //            foreach (ML.EntregaEquipo entregaEquipoItem in resultData.Objects)
        //            {
        //                ML.Result resultAdd = BL.EntregaEquipo.Add(entregaEquipoItem);
        //                if (!resultAdd.Correct)
        //                {
        //                    //resultErrores.Objects.Add("No se insertó el empleado con nombre: " + entregaEquipoItem.NumeroEmpleado + " Rfc:" + entregaEquipoItem.Rfc
        //                    //    + "Nombre:" + entregaEquipoItem.Nombre + "ApellidoPaterno" + empleado.ApellidoPaterno + "ApellidoMaterno" + empleado.ApellidoMaterno + "Email"
        //                    //    + empleado.Email + "Telefono" + empleado.Telefono + "FechaNacimiento" + empleado.FechaNacimiento + "Nss" + empleado.Nss + "FechaIngreso"
        //                    //    + empleado.FechaIngreso + "Foto" + empleado.Foto + "IdEmpresa" + empleado.Empresa.IdEmpresa + "IdEmpleado" + empleado.IdEmpleado + " Error: " + resultAdd.ErrorMessage);

        //                }
        //            }
        //            if (resultErrores.Objects.Count > 0)
        //            {
        //                string folderError = _configuration["PathFolderError:value"];
        //                string fileError = Path.Combine(_hostingEnvironment.WebRootPath, folderError + @"\logErrores.txt");
        //                using (StreamWriter writer = new StreamWriter(fileError))
        //                {
        //                    foreach (string ln in resultErrores.Objects)
        //                    {
        //                        writer.WriteLine(ln);
        //                    }
        //                }
        //                ViewBag.Message = "Los Empleados No han sido registrados correctamente";
        //            }
        //            else
        //            {
        //                ViewBag.Message = "Los Empleados han sido registrados correctamente";
        //            }
        //        }
        //    }
        //    return PartialView("Modal");
        //}
    }
}
