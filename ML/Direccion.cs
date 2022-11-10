using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Direccion
    {
        public int? IdDireccion { get; set; }
        [Required(ErrorMessage = "Calle es requerido")]
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        [Required(ErrorMessage = "Numero exterior es requerido")]
        public string NumeroExterior { get; set; }
        public ML.Operadora? Operadora { get; set; }
        public ML.Colonia? Colonia { get; set; }
    }
}
