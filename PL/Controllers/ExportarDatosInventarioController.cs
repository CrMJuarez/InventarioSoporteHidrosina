using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Core.ExcelPackage;
using Microsoft.Office.Interop;
namespace PL.Controllers
{
    public class ExportarDatosInventarioController : Controller
    {
        //public IActionResult ExportarExcel()
        //{
        //    string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    var productos = _context.Productos.AsNoTracking().ToList();
        //    using (var libro = new ExcelPackage())
        //    {
        //        var worksheet = libro.Workbook.Worksheets.Add("Productos");
        //        worksheet.Cells["A1"].LoadFromCollection(productos, PrintHeaders: true);
        //        for (var col = 1; col < productos.Count + 1; col++)
        //        {
        //            worksheet.Column(col).AutoFit();
        //        }

        //        // Agregar formato de tabla
        //        var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: productos.Count + 1, toColumn: 5), "Productos");
        //        tabla.ShowHeader = true;
        //        tabla.TableStyle = TableStyles.Light6;
        //        tabla.ShowTotal = true;

        //        return File(libro.GetAsByteArray(), excelContentType, "Productos.xlsx");
        //    }
        //}
       
    }
}
