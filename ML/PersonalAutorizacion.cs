using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class PersonalAutorizacion
    {
        public int? IdPersonalAutorizacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public List<object> Personales { get; set; }
    }
}
