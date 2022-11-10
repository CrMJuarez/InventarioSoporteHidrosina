using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Colonia
    {
        public int IdColonia { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoPostal { get; set; }
        public ML.Municipio? Municipio { get; set; }
        public List<object>? Colonias { get; set; }
    }
}
