using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEBAPI.Controllers
{

    public class InventarioController : ControllerBase
    {
        [HttpGet]
        [Route("api/inventario/GetAll")]
        public IActionResult GetAll()
        {
            ML.Inventario inventario = new ML.Inventario();

            ML.Result result = BL.Inventario.GetAll(inventario);


            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet]
        [Route("api/inventario/GetbyId/{IdInventario}")]

        public IActionResult GetById(int IdInventario)
        {
            var result = BL.Inventario.GetById(IdInventario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
