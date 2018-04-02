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
    public class SubtitulosController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Subtitulos
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    return View(db.Subtitulos.ToList());
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // GET: Subtitulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtitulo subtitulo = db.Subtitulos.Find(id);
            if (subtitulo == null)
            {
                return HttpNotFound();
            }
            return View(subtitulo);
        }

        // GET: Subtitulos/Create
        public ActionResult Create()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    var titulosList = from Titulo in db.Titulos
                                      select Titulo;
                    Modelos modelos = new Modelos();
                    modelos.ObjTitulo = titulosList;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: Subtitulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id = 0, string nombre = "",
                                    int tituloId = 0)
        {
            var titulo = db.Titulos.SingleOrDefault(x => x.id == tituloId);
            try
            {
                var subtituloAdd = new Subtitulo();
                subtituloAdd.nombre = nombre;
                subtituloAdd.Titulo = titulo;
                db.Subtitulos.Add(subtituloAdd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Subtitulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    //consulta de usuarios con perfil de coordinador
                    var titulosList = from Titulo in db.Titulos
                                      select Titulo;

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Subtitulo subtitulo = db.Subtitulos.Find(id);
                    if (subtitulo == null)
                    {
                        return HttpNotFound();
                    }

                    Modelos modelos = new Modelos();
                    modelos.ObjTitulo = titulosList;
                    modelos.Subtitulo = subtitulo;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Subtitulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,Titulo")] Subtitulo subtitulo, int tituloId = 0)
        {
            try
            {
                var titulo = db.Titulos.SingleOrDefault(x => x.id == tituloId);

                var subtituloEdit = db.Subtitulos.Find(subtitulo.id);
                subtituloEdit.nombre = subtitulo.nombre;
                subtituloEdit.Titulo = titulo;
                db.Entry(subtituloEdit).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(subtitulo);
            }
        }

        // GET: Subtitulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Subtitulo subtitulo = db.Subtitulos.Find(id);
                    if (subtitulo == null)
                    {
                        return HttpNotFound();
                    }
                    return View(subtitulo);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Subtitulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subtitulo subtitulo = db.Subtitulos.Find(id);
            db.Subtitulos.Remove(subtitulo);
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
    }
}
