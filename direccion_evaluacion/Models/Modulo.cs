using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace direccion_evaluacion.Models
{
    public class Modulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string ruta { get; set; }
        public  List<Ficha> Fichas { get; set; }

    }
}