using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace direccion_evaluacion.Models
{
    public class Item
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion_archivo { get; set; }
        public virtual Subtitulo Subtitulo { get; set; }
    }
}