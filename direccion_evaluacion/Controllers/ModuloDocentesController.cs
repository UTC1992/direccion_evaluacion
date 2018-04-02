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
    public class ModuloDocentesController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: ModuloDocentes
        public ActionResult Index()
        {
            return View(db.ModuloDocentes.ToList());
        }

        // GET: ModuloDocentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuloDocente moduloDocente = db.ModuloDocentes.Find(id);
            if (moduloDocente == null)
            {
                return HttpNotFound();
            }
            return View(moduloDocente);
        }

        // GET: ModuloDocentes/Create
        public ActionResult Create(int id = 0)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    var modulosList = from Modulo in db.Modulos
                                      select Modulo;
                    var md = from ModuloDocente in db.ModuloDocentes
                                      select ModuloDocente;
                    Usuario docente = db.Usuarios.Find(id);

                    Modelos modelos = new Modelos();
                    modelos.ObjModulo = modulosList;
                    modelos.Usuario = docente;
                    modelos.ObjModuloD = md;
                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: ModuloDocentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int usuarioId = 0,
                                    int moduloId= 0, string rutaModulo="")
        {
            var modulo = db.Modulos.SingleOrDefault(x => x.id == moduloId);
            var usuario = db.Usuarios.SingleOrDefault(x => x.id == usuarioId);
            try
            {
                var moduloDocente = new ModuloDocente();
                moduloDocente.Modulo = modulo;
                moduloDocente.Docente = usuario;
                moduloDocente.rutaModulo = rutaModulo;
                db.ModuloDocentes.Add(moduloDocente);
                db.SaveChanges();

                return Redirect("/Docentes/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ModuloDocentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ModuloDocente moduloDocente = db.ModuloDocentes.Find(id);
                    if (moduloDocente == null)
                    {
                        return HttpNotFound();
                    }
                    var modulosList = from Modulo in db.Modulos
                                      select Modulo;
                    var docentesList = from Usuario in db.Usuarios
                                       select Usuario;
                    var md = from ModuloDocente in db.ModuloDocentes
                             select ModuloDocente;
                    Modelos modelos = new Modelos();
                    modelos.ObjModulo = modulosList;
                    modelos.ObjUsuario = docentesList;
                    modelos.ModuloDocente = moduloDocente;
                    modelos.ObjModuloD = md;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }


        // POST: ModuloDocentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int moduloId = 0, string rutaModulo = "", int id = 0 )
        {
            var modulo = db.Modulos.SingleOrDefault(x => x.id == moduloId);
            try
            {
                var moduloDocente = db.ModuloDocentes.Find(id);
                moduloDocente.Modulo = modulo;
                moduloDocente.rutaModulo = rutaModulo;
                db.Entry(moduloDocente).State = EntityState.Modified;
                db.SaveChanges();

                return Redirect("/Docentes/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ModuloDocentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuloDocente moduloDocente = db.ModuloDocentes.Find(id);
            if (moduloDocente == null)
            {
                return HttpNotFound();
            }
            return View(moduloDocente);
        }

        // POST: ModuloDocentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuloDocente moduloDocente = db.ModuloDocentes.Find(id);
            db.ModuloDocentes.Remove(moduloDocente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        public JsonResult getFichasDocentes(int id = 0)
        {
            var usuario = db.Usuarios.SingleOrDefault(x => x.id == id);
            //var docenteModulos = db.ModuloDocentes.SingleOrDefault(x => x.Docente.id == id);
            var docentesModulosList = from ModuloDocente in db.ModuloDocentes
                                      select ModuloDocente;
            var moduloList = from Modulo in db.Modulos
                             select Modulo;
            var fichaList = from Ficha in db.Fichas
                            select Ficha;

            var diccionario = new Dictionary<string, object>();

            foreach (var md in docentesModulosList.ToList())
            {
                foreach (var mod in moduloList.ToList())
                {
                    if (md.Modulo.id == mod.id && md.Docente.id == id)
                    {
                        foreach (var fichas in fichaList.ToList())
                        {
                            diccionario.Add("nombre", fichas.nombre);
                        }
                    }
                }
            }
            return  Json(diccionario, JsonRequestBehavior.AllowGet);
        }
    }
}
