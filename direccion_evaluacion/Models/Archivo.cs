using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using direccion_evaluacion.Models;


namespace direccion_evaluacion.Models
{
    public class Archivo
    {
        public int id { get; set; }
        public int codigoItem { get; set; }
        public string nombre { get; set; }
        public string ruta { get; set; }
        public string estado { get; set; }
        public string comentarioD { get; set; }
        public string comentarioC { get; set; }
    }
}