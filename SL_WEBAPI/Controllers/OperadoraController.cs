using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEBAPI.Controllers
{

    public class OperadoraController : ControllerBase
    {
        [HttpGet]
        [Route("api/operadora/GetAll")]
        public IActionResult GetAll()
        {
            ML.Operadora operadora = new ML.Operadora();
            ML.Result result = BL.Operadora.GetAll(operadora);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        //[HttpPost]
        //[Route("api/operadora/add")]
        //public IActionResult Add([FromBody] ML.Operadora operadora)
        //{

        //    var result = BL.Operadora.Add(operadora);

        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound(result);
        //    }
        //}

        //[HttpPut]
        //[Route("api/operadora/update")]
        //public IActionResult Update([FromBody] ML.Operadora operadora)
        //{
        //    var result = BL.Operadora.Update(operadora);

        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //}

        //[HttpDelete]
        //[Route("api/operadora/delete")]
        //public IActionResult Delete(int IdDireccion, int IdUsuario)
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    usuario.Direccion = new ML.Direccion();
        //    usuario.Direccion.IdDireccion = IdDireccion;
        //    usuario.IdUsuario = IdUsuario;
        //    var result = BL.Usuario.Delete(usuario.Direccion.IdDireccion.Value, usuario.IdUsuario.Value);

        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpGet]
        [Route("api/operadora/GetbyId/{IdOperadora}")]
        public IActionResult GetById(int IdOperadora)
        {
            ML.Operadora operadora = new ML.Operadora();
            operadora.IdOperadora = IdOperadora;

            var result = BL.Operadora.GetById(operadora.IdOperadora.Value);

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
