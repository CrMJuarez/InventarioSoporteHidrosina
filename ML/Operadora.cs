using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Operadora
    {
        public int? IdOperadora { get; set; }
        public string NombreCorto { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string RFC { get; set; }
        public List<object> Operadoras { get; set; }
    }
}
