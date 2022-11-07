using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace ML
{
    public class Usuario
    {
        public int? IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Debes insertar nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Debes insertar contraseña")]
        public string Contrasenia { get; set; }
        public bool Estatus { get; set; }
        public string Email { get; set; } = null!;
        public ML.Rol Rol { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
