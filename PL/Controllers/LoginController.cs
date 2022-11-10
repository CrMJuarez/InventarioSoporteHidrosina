using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Login(string contrasenia, string nombreusuario)
        {
            if (contrasenia == "" || contrasenia == null || contrasenia.Equals(""))
            {
                ViewBag.Message = "Usuario o contraseña no ingresado.";
                return PartialView("Modal");
            }
            if (nombreusuario == "" || nombreusuario == null || nombreusuario.Equals(""))
            {
                ViewBag.Message = "Usuario o contraseña no ingresado.";
                return PartialView("Modal");
            }
            ML.Result result = BL.Usuario.GetByNombreUsuario(nombreusuario);
            if (result.Correct)
            {
                ML.Usuario usuario = ((ML.Usuario)result.Object);
                if (usuario.Contrasenia == contrasenia)
                {
                    if (usuario.Estatus == true)
                    {
                        if (usuario.Rol.IdRol == 1)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("GetAll", "Inventario");
                        }

                    }
                    else
                    {
                        ViewBag.Message = "Este usuario se encuentra inactivo.";
                        return PartialView("Modal");
                    }
                }
                else
                {
                    ViewBag.Message = "La contraseña no coincide, intente de nuevo";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Message = "El usuario no existe, intente de nuevo";
                return PartialView("Modal");
            }
        }

        public ActionResult LoginContrasena()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }
        [HttpPost]

        public ActionResult LoginContrasena(string nombreusuario)
        {
            
            //recuperacion de contrasena
            ML.Result result = BL.Usuario.GetByNombreUsuario(nombreusuario);
            if (result.Correct)
            {
                ML.Usuario usuario = ((ML.Usuario)result.Object);
                if (usuario.NombreUsuario == nombreusuario)
                {
                    ViewBag.Message = "Su contraseña es:"+usuario.Contrasenia;
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "El nombre de usuario no existe, intente de nuevo";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Message = "El usuario no existe, intente de nuevo";
                return PartialView("Modal");
            }
        }
    }
}
