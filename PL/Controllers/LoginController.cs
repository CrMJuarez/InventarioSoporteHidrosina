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
            ML.Result result = BL.Usuario.GetByNombreUsuario(nombreusuario);
            if (result.Correct)
            {
                ML.Usuario usuario = ((ML.Usuario)result.Object);
                if (usuario.Contrasenia == contrasenia)
                {
                    return RedirectToAction("Usuario", "GetAll");
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
    }
}
