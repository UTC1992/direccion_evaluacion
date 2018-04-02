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
    public class TitulosController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Titulos
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    return View(db.Titulos.ToList());
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // GET: Titulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        // GET: Titulos/Create
        public ActionResult Create()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    //db.Titulos.ToList()
                    var fichasList = from Ficha in db.Fichas
                                     select Ficha;
                    Modelos modelos = new Modelos();
                    modelos.ObjFicha = fichasList;
                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Titulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id = 0, string nombre = "",
                                    int fichaId = 0)
        {
            var ficha = db.Fichas.SingleOrDefault(x => x.id == fichaId);
            try
            {
                var tituloAdd = new Titulo();
                tituloAdd.nombre = nombre;
                tituloAdd.Ficha = ficha;
                db.Titulos.Add(tituloAdd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Titulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    //consulta de usuarios con perfil de coordinador
                    var fichasList = from Ficha in db.Fichas
                                     select Ficha;

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Titulo titulo = db.Titulos.Find(id);
                    if (titulo == null)
                    {
                        return HttpNotFound();
                    }

                    Modelos modelos = new Modelos();
                    modelos.ObjFicha = fichasList;
                    modelos.Titulo = titulo;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Titulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,Ficha")] Titulo titulo, int fichaId = 0)

        {
            try
            {
                var ficha = db.Fichas.SingleOrDefault(x => x.id == fichaId);

                var tituloEdit = db.Titulos.Find(titulo.id);
                tituloEdit.nombre = titulo.nombre;
                tituloEdit.Ficha = ficha;
                db.Entry(tituloEdit).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(titulo);
            }
        }

        // GET: Titulos/Delete/5
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
                    Titulo titulo = db.Titulos.Find(id);
                    if (titulo == null)
                    {
                        return HttpNotFound();
                    }
                    return View(titulo);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Titulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Titulo titulo = db.Titulos.Find(id);
            db.Titulos.Remove(titulo);
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
