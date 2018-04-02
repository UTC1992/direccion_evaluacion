using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace direccion_evaluacion.Models
{
    public class Ficha
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public virtual Modulo Modulo { get; set; }
        public List<Titulo> Titulos { get; set; }

       
    }
}