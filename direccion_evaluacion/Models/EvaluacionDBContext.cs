using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace direccion_evaluacion.Models
{
    public class EvaluacionDBContext : DbContext
    {
        public EvaluacionDBContext()
            :base ("DireccionEvaluacionDB")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}