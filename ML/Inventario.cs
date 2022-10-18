using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Inventario
    {
        public int? IdInventario { get; set; }
        public string NumeroSerie { get; set; }
        public string NIAF { get; set; }
        public string Responsable { get; set; }
        public string Comentario { get; set; }
        public ML.TipoEquipo TipoEquipo { get; set; }
        public ML.Marca Marca { get; set; }
        public ML.Modelo Modelo { get; set; }
        public ML.DireccionEntrada DireccionEntrada { get; set; }
        public List<object> Inventarios { get; set; }
    }
}
