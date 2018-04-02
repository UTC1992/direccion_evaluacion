using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using direccion_evaluacion.Controllers;
using direccion_evaluacion.Models;


namespace direccion_evaluacion.Controllers
{
    public class SubirArchivosController : Controller
    {
        EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: SubirArchivos
        public ActionResult Index()
        {
            return View();
        }

        //get subir Archivo
        public ActionResult SubirArchivo(int id = 0, string ficha = "", string ruta = "")
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Docente")
                {
                    ViewBag.IdItem = id;
                    ViewBag.ficha = ficha;
                    ViewBag.ruta = ruta;
                    return View();
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        //post subir Archivo
        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase file, int idItem = 0, string ficha = "", string rutaFile = "")

        {
            SubirArchivosModelo modelo = new SubirArchivosModelo();
            if (file != null)
            {
                //se optiene la ruta del directorio donde se guardara el archivo
                String ruta = Server.MapPath("~"+rutaFile);
                
                //creacion del resgistro de los datos del archivo subido
                var archivoAdd = new Archivo();
                archivoAdd.nombre = file.FileName;
                archivoAdd.ruta = ruta;
                archivoAdd.codigoItem = idItem;

                //creacion de ruta completa con nombre de archivo
                //y subida del archivo 
                ruta += file.FileName;
                modelo.SubirArchivo(ruta, file);

                //volvemos a la creacion del registro del archivo
                if (modelo.Estado == "1")
                {
                    archivoAdd.estado = "1";
                }
                else
                {
                    archivoAdd.estado = "0";
                }
                db.Archivos.Add(archivoAdd);
                db.SaveChanges();

                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;
                ViewBag.ficha = ficha;
            }

            return View();
        }

        //get subir Archivo
        public ActionResult EditarArchivo(int id = 0, string ficha = "", string ruta = "")
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Docente")
                {
                    ViewBag.IdItem = id;
                    ViewBag.ficha = ficha;
                    ViewBag.ruta = ruta;
                    return View();
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        //post editar Archivo
        [HttpPost]
        public ActionResult EditarArchivo(HttpPostedFileBase file, int idItem = 0, string ficha = "", string rutaFile = "")
        {
            SubirArchivosModelo modelo = new SubirArchivosModelo();
            if (file != null)
            {
                //se optiene la ruta del directorio donde se guardara el archivo
                String ruta = Server.MapPath("~"+rutaFile);
                String auxRuta = Server.MapPath("~"+rutaFile);

                var archivo = db.Archivos.SingleOrDefault(x => x.codigoItem == idItem);

                //creacion del resgistro de los datos del archivo subido

                var archivoEdit = db.Archivos.Find(archivo.id);
                string auxName = archivoEdit.nombre; //guardamos el nombre del archivo antiguo  
                archivo.nombre = file.FileName;
                archivoEdit.ruta = ruta;
                archivoEdit.codigoItem = idItem;

                //creacion de ruta completa con nombre de archivo
                //y subida del archivo 
                ruta += file.FileName;
                modelo.EditarArchivo(ruta, file);
                //eliminar archivo antiguo
                DeleteFile eliminarFile = new DeleteFile();
                eliminarFile.Borrar(auxRuta + "" + auxName);
                //volvemos a la creacion del registro del archivo
                if (modelo.Estado == "1")
                {
                    archivoEdit.estado = "1";
                }
                else
                {
                    archivoEdit.estado = "0";
                }
                db.Archivos.Add(archivoEdit);
                db.Entry(archivoEdit).State = EntityState.Modified;
                db.SaveChanges();

                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;
                ViewBag.ficha = ficha;
            }

            return View();
        }

        public bool observacionesDocente(int idRes = 0, string observaciones = "") 
        {
            try
            {
                var archivo = db.Archivos.SingleOrDefault(x => x.id == idRes);
                var archivoComentario = db.Archivos.Find(archivo.id);
                archivoComentario.comentarioD = observaciones;
                db.Archivos.Add(archivoComentario);
                db.Entry(archivoComentario).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool observacionesCoor(int idRes = 0, string observaciones = "")
        {
            try
            {
                var archivo = db.Archivos.SingleOrDefault(x => x.id == idRes);
                var archivoComentario = db.Archivos.Find(archivo.id);
                archivoComentario.comentarioC = observaciones;
                db.Archivos.Add(archivoComentario);
                db.Entry(archivoComentario).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}