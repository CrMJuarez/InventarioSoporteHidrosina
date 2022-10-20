using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class EntregaEquipo
    {
        public int? IdEntregaEquipo { get; set; }
        public string Destino { get; set; }
        public string NumeroSerie{ get; set; }
    public string RazonSocial { get; set; }
        public string Entrega { get; set; }
        public string Recibe { get; set; }
        public string NombreEquipo { get; set; }
        public string Justificacion { get; set; }
        public string Autorizacion { get; set; }
        public List<object> Entregas { get; set; }
    }
}
