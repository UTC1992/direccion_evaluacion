using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace direccion_evaluacion.Models
{
    public class FichaAux
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public virtual Subcriterio Subcriterio { get; set; }
    }
}