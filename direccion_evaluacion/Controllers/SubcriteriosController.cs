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
    public class SubcriteriosController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Subcriterios
        public ActionResult Index()
        {
            return View(db.Subcriterios.ToList());
        }

        // GET: Subcriterios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcriterio subcriterio = db.Subcriterios.Find(id);
            if (subcriterio == null)
            {
                return HttpNotFound();
            }
            return View(subcriterio);
        }

        // GET: Subcriterios/Create
        public ActionResult Create()
        {
            var modulosList = from Modulo in db.Modulos
                              select Modulo;
            Modelos modelos = new Modelos();
            modelos.ObjModulo = modulosList;

            return View(modelos);
        }

        // POST: Subcriterios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Subcriterio subcriterio)
        {
            if (ModelState.IsValid)
            {
                db.Subcriterios.Add(subcriterio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subcriterio);
        }

        // GET: Subcriterios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcriterio subcriterio = db.Subcriterios.Find(id);
            if (subcriterio == null)
            {
                return HttpNotFound();
            }
            return View(subcriterio);
        }

        // POST: Subcriterios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] Subcriterio subcriterio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcriterio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subcriterio);
        }

        // GET: Subcriterios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcriterio subcriterio = db.Subcriterios.Find(id);
            if (subcriterio == null)
            {
                return HttpNotFound();
            }
            return View(subcriterio);
        }

        // POST: Subcriterios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcriterio subcriterio = db.Subcriterios.Find(id);
            db.Subcriterios.Remove(subcriterio);
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
