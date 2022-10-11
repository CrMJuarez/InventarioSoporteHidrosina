using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public bool Estatus { get; set; }
        public ML.Rol Rol { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
