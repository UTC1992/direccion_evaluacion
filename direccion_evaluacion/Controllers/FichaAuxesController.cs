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
    public class FichaAuxesController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: FichaAuxes
        public ActionResult Index()
        {
            return View(db.FichaAuxes.ToList());
        }

        // GET: FichaAuxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAux fichaAux = db.FichaAuxes.Find(id);
            if (fichaAux == null)
            {
                return HttpNotFound();
            }
            return View(fichaAux);
        }

        // GET: FichaAuxes/Create
        public ActionResult Create()
        {
            var subcriterioList = from Subcriterio in db.Subcriterios
                              select Subcriterio;
            Modelos modelos = new Modelos();
            modelos.ObjSubcriterio = subcriterioList;

            return View(modelos);
        }

        // POST: FichaAuxes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] FichaAux fichaAux)
        {
            if (ModelState.IsValid)
            {
                db.FichaAuxes.Add(fichaAux);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fichaAux);
        }

        // GET: FichaAuxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAux fichaAux = db.FichaAuxes.Find(id);
            if (fichaAux == null)
            {
                return HttpNotFound();
            }
            return View(fichaAux);
        }

        // POST: FichaAuxes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] FichaAux fichaAux)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaAux).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fichaAux);
        }

        // GET: FichaAuxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAux fichaAux = db.FichaAuxes.Find(id);
            if (fichaAux == null)
            {
                return HttpNotFound();
            }
            return View(fichaAux);
        }

        // POST: FichaAuxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FichaAux fichaAux = db.FichaAuxes.Find(id);
            db.FichaAuxes.Remove(fichaAux);
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
