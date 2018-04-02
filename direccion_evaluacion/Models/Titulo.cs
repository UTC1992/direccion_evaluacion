using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace direccion_evaluacion.Models
{
    public class Titulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public virtual Ficha Ficha { get; set; }
        public List<Subtitulo> Subtitulos { get; set; }
    }
}