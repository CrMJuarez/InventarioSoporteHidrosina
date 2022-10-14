using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Modelo
    {
        public int? IdModelo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ML.Marca Marca  { get; set; }
        public List<object> Modelos { get; set; }
    }
}
