using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class EntregaEquipo
    {
        public int? IdEntregaEquipo { get; set; }
        public ML.DireccionDestino direccionDestino { get; set; }
        public ML.PersonalEntrega personalEntrega { get; set; }
        public ML.PersonalAutorizacion personalAutorizacion { get; set; }
        public ML.Operadora operadora { get; set; }
        public ML.Inventario inventario { get; set; }    
        public ML.TipoEquipo TipoEquipo { get; set; }
        public string Recibe { get; set; }  
        public string Justificacion { get; set; }
        public List<object> Entregas { get; set; }
    }
}
