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
    public class ModulosController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Modulos
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    return View(db.Modulos.ToList());
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // GET: Modulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = db.Modulos.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // GET: Modulos/Create
        public ActionResult Create()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    return View();
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Modulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Modulos.Add(modulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modulo);
        }

        // GET: Modulos/Edit/5
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
                    Modulo modulo = db.Modulos.Find(id);
                    if (modulo == null)
                    {
                        return HttpNotFound();
                    }
                    return View(modulo);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Modulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modulo);
        }

        // GET: Modulos/Delete/5
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
                    Modulo modulo = db.Modulos.Find(id);
                    if (modulo == null)
                    {
                        return HttpNotFound();
                    }
                    return View(modulo);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Modulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modulo modulo = db.Modulos.Find(id);
            db.Modulos.Remove(modulo);
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
