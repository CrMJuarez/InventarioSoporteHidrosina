using BL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();
            ML.Result resultRol = BL.Rol.GetAll();
            usuario.Rol = new ML.Rol();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects.ToList();
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRol.Objects.ToList();
                return View(usuario);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetById(IdUsuario);
            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
                return View();
            }
        }
    }
}

