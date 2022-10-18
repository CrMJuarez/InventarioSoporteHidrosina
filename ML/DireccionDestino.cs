using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class DireccionDestino
    {
        public int? IdDireccionDestino { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroExterior { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public ML.Operadora Operadora { get; set; }
        public List<object> Direcciones { get; set; }
    }
}
