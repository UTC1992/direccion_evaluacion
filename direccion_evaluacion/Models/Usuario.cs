﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace direccion_evaluacion.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string password { get; set; }
        public string estado { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
    
}