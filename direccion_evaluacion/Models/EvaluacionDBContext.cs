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
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Subtitulo> Subtitulos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<ModuloDocente> ModuloDocentes { get; set; }
        public DbSet<Subcriterio> Subcriterios { get; set; }
        public DbSet<FichaAux> FichaAuxes { get; set; }
    }
}