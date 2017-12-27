using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace direccion_evaluacion.Models
{
    public class Perfil
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}