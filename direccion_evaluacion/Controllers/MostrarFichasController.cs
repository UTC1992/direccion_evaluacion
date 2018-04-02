using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using direccion_evaluacion.Models;

namespace direccion_evaluacion.Controllers
{
    public class MostrarFichasController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();
        // GET: MostrarFichas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ficha1Mod1(string nombre = "")
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Docente")
                {
                    var Fi = db.Fichas.FirstOrDefault(x => x.nombre == nombre);
                    var mdRuta = db.ModuloDocentes.FirstOrDefault(x => x.Modulo.id == Fi.Modulo.id);

                    ViewBag.ruta = mdRuta.rutaModulo;

                    //consulta de titulos a fichas
                    var Titulos = from Titulo in db.Titulos
                                  where Titulo.Ficha.nombre == nombre
                                  select Titulo;
                    var Subtitulos = from Subtitulo in db.Subtitulos
                                     select Subtitulo;
                    var Items = from Item in db.Items
                                select Item;
                    var Archivos = from Archivo in db.Archivos
                                   select Archivo;
                    var md = from ModuloDocente in db.ModuloDocentes
                             select ModuloDocente;

                    Modelos modelos = new Modelos();
                    modelos.ObjTitulo = Titulos;
                    modelos.ObjSubtitulo = Subtitulos;
                    modelos.ObjItem = Items;
                    modelos.ObjArchivo = Archivos;
                    modelos.ObjModuloD = md;

                    ViewBag.ficha = nombre;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            

        }
        public ActionResult Ficha1Mod1C(string nombre = "")
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    var Fi = db.Fichas.FirstOrDefault(x => x.nombre == nombre);
                    var mdRuta = db.ModuloDocentes.FirstOrDefault(x => x.Modulo.id == Fi.Modulo.id);

                    ViewBag.ruta = mdRuta.rutaModulo;

                    //consulta de titulos a fichas
                    var Titulos = from Titulo in db.Titulos
                                  where Titulo.Ficha.nombre == nombre
                                  select Titulo;
                    var Subtitulos = from Subtitulo in db.Subtitulos
                                     select Subtitulo;
                    var Items = from Item in db.Items
                                select Item;
                    var Archivos = from Archivo in db.Archivos
                                   select Archivo;
                    var md = from ModuloDocente in db.ModuloDocentes
                             select ModuloDocente;

                    Modelos modelos = new Modelos();
                    modelos.ObjTitulo = Titulos;
                    modelos.ObjSubtitulo = Subtitulos;
                    modelos.ObjItem = Items;
                    modelos.ObjArchivo = Archivos;
                    modelos.ObjModuloD = md;


                    ViewBag.ficha = nombre;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            

        }

        
    }
}