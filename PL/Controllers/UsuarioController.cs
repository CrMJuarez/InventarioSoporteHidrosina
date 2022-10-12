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
            //ML.Result resultRol = BL.Rol.GetAll();
           // usuario.Rol = new ML.Rol();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects.ToList();
                usuario.Rol = new ML.Rol();
                //usuario.Rol.Roles = resultRol.Objects.ToList();
                return View(usuario);
            }
            else
                ViewBag.Message = "ocurrio un problema" + result.ErrorMessage;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRol = BL.Rol.GetAll();
            usuario.Rol = new ML.Rol();
            if (IdUsuario == null)
            {
                //usuario = (ML.Usuario)result.Object;
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRol.Objects.ToList();
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRol.Objects.ToList();
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
}

