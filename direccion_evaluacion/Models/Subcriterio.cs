using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace direccion_evaluacion.Models
{
    public class Subcriterio
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public virtual Modulo Modulo { get; set; }
        public List<FichaAux> FichaAux { get; set; }

    }
}