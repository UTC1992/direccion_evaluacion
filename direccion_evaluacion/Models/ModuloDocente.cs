using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace direccion_evaluacion.Models
{
    public class ModuloDocente
    {
        public int id { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Usuario Docente { get; set; }
        public string rutaModulo { get; set; }
    }
}