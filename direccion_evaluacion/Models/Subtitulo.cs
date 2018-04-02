using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace direccion_evaluacion.Models
{
    public class Subtitulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public virtual Titulo Titulo { get; set; }
        public List<Item> Items { get; set; }
    }
}