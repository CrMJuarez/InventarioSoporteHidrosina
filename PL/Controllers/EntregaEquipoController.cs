using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PL.Controllers
{
    public class EntregaEquipoController : Controller
    {
        public ActionResult GetAll()
        {
            ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();
            // ML.Result result = BL.Inventario.GetAll();
            //ML.Result resultRol = BL.Rol.GetAll();
            // usuario.Rol = new ML.Rol();


            // entregaEquipo.Inventarios = result.Objects.ToList();
            return View(entregaEquipo);


        }
        public ActionResult Form(int? IdInventario)
        {
            ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();
            //ML.Result resultRol = BL.Rol.GetAll();

            //usuario.Rol = new ML.Rol();
            //Tipo equipo
            //marca
            //modelo
            //direccionentrda

            //usuario = (ML.Usuario)result.Object;
            //usuario.Rol = new ML.Rol();
            // usuario.Rol.Roles = resultRol.Objects.ToList();
            return View(entregaEquipo);
            }
        }
    }

