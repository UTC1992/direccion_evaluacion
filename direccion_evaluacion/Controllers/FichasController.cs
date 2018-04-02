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
    public class FichasController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Fichas
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    return View(db.Fichas.ToList());
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
                    
        }

        // GET: Fichas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ficha ficha = db.Fichas.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            return View(ficha);
        }

        // GET: Fichas/Create
        public ActionResult Create()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    var modulosList = from Modulo in db.Modulos
                                      select Modulo;
                    Modelos modelos = new Modelos();
                    modelos.ObjModulo = modulosList;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }

            
        }

        // POST: Fichas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id = 0, string nombre = "",
                                    int moduloId = 0)
        {
            var modulo = db.Modulos.SingleOrDefault(x => x.id == moduloId);
            try
            {
                var fichaAdd = new Ficha();
                fichaAdd.nombre = nombre;
                fichaAdd.Modulo = modulo;
                db.Fichas.Add(fichaAdd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Fichas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    //consulta de usuarios con perfil de coordinador
                    var modulosList = from Modulo in db.Modulos
                                      select Modulo;

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Ficha ficha = db.Fichas.Find(id);
                    if (ficha == null)
                    {
                        return HttpNotFound();
                    }

                    Modelos modelos = new Modelos();
                    modelos.ObjModulo = modulosList;
                    modelos.Ficha = ficha;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Fichas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,Modulo")] Ficha ficha, int moduloId = 0)
        {
            try
            {
                var modulo = db.Modulos.SingleOrDefault(x => x.id == moduloId);

                var fichaEdit = db.Fichas.Find(ficha.id);
                fichaEdit.nombre = ficha.nombre;
                fichaEdit.Modulo = modulo;
                db.Entry(fichaEdit).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(ficha);
            }
        }

        // GET: Fichas/Delete/5
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
                    Ficha ficha = db.Fichas.Find(id);
                    if (ficha == null)
                    {
                        return HttpNotFound();
                    }
                    return View(ficha);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ficha ficha = db.Fichas.Find(id);
            db.Fichas.Remove(ficha);
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
