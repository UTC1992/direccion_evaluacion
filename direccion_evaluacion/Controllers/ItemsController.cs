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
    public class ItemsController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Items
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    return View(db.Items.ToList());
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            //db.Fichas.ToList()
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    var subtitulosList = from Subtitulo in db.Subtitulos
                                         select Subtitulo;
                    Modelos modelos = new Modelos();
                    modelos.ObjSubtitulo = subtitulosList;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Items/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(int id = 0, string nombre = "",
                                    int subtituloId = 0)
        {
            var subtitulo = db.Subtitulos.SingleOrDefault(x => x.id == subtituloId);
            try
            {
                var itemAdd = new Item();
                itemAdd.nombre = nombre;
                itemAdd.Subtitulo = subtitulo;
                db.Items.Add(itemAdd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    //consulta de usuarios con perfil de coordinador
                    var subtitulosList = from Subtitulo in db.Subtitulos
                                         select Subtitulo;

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Item item = db.Items.Find(id);
                    if (item == null)
                    {
                        return HttpNotFound();
                    }

                    Modelos modelos = new Modelos();
                    modelos.ObjSubtitulo = subtitulosList;
                    modelos.Item = item;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }
        // POST: Items/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,Subtitulo")] Item item, int subtituloId = 0)
        {
            try
            {
                var subtitulo = db.Subtitulos.SingleOrDefault(x => x.id == subtituloId);

                var itemEdit = db.Items.Find(item.id);
                itemEdit.nombre = item.nombre;
                itemEdit.Subtitulo = subtitulo;
                db.Entry(itemEdit).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        // GET: Items/Delete/5
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
                    Item item = db.Items.Find(id);
                    if (item == null)
                    {
                        return HttpNotFound();
                    }
                    return View(item);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
