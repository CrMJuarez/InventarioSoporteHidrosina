using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEBAPI.Controllers
{
    
    public class DireccionEntradaController : ControllerBase
    {
        [HttpGet]
        [Route("api/direccionEntrada/GetAll")]
        public IActionResult GetAll()
        {
            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
            ML.Result result = BL.DireccionEntrada.GetAll(direccionEntrada);

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
        [Route("api/direccionEntrada/GetbyId/{IdDireccionEntrada}")]
        public IActionResult GetById(int IdDireccionEntrada)
        {
            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
            direccionEntrada.IdDireccionEntrada = IdDireccionEntrada;

            var result = BL.DireccionEntrada.GetById(direccionEntrada.IdDireccionEntrada.Value);

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
