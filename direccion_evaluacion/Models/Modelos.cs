using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using direccion_evaluacion.Models;
using System.ComponentModel.DataAnnotations;

namespace direccion_evaluacion.Models
{
    public class Modelos
    {
     
        public Modulo Modulo { get; set; }
        public Ficha Ficha { get; set; }
        public Titulo Titulo { get; set; }
        public Subtitulo Subtitulo { get; set; }
        public Item Item { get; set; }
        public Usuario Usuario { get; set; }
        public ModuloDocente ModuloDocente { get; set; }
        public IEnumerable<Modulo> ObjModulo { get; set; }
        public IEnumerable<Ficha> ObjFicha { get; set; }
        public IEnumerable<Titulo> ObjTitulo { get; set; }
        public IEnumerable<Subtitulo> ObjSubtitulo { get; set; }
        public IEnumerable<Item> ObjItem{ get; set; }
        public IEnumerable<Archivo> ObjArchivo{ get; set; }
        public IEnumerable<Usuario> ObjUsuario { get; set; }
        public IEnumerable<ModuloDocente> ObjModuloD { get; set; }

    }
}