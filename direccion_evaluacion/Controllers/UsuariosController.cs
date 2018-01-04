using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using direccion_evaluacion.Models;
using System.Data.Entity;

namespace direccion_evaluacion.Controllers
{
    public class UsuariosController : Controller
    {
        EvaluacionDBContext db = new EvaluacionDBContext();
        
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Perfil/5
        public ActionResult Perfil(int id = 0)
        {
            ViewBag.email = Session["email"];
            ViewBag.usuario = Session["usuario"];
            ViewBag.Id = Session["Id"];
            ViewBag.nombre = Session["nombre"];
            ViewBag.apellido = Session["apellido"];

            if (Session["usuario"] != null)
            {
                Usuario usu = db.Usuarios.Find(id);
                return View(usu);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Perfil([Bind(Include = "id,nombre,apellido,cedula,email,telefono,direccion,password,estado")]
                                    Usuario usuario, string tipoFormulario = "", int ID = 0,
                                    string passant = "", string passnue = "", string passrep = "")
        {
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            try
            {
                switch(tipoFormulario)
                {
                    case "personales":
                        if (ModelState.IsValid)
                        {
                            var usu = db.Entry(usuario);
                            usu.State = EntityState.Modified;
                            usu.Property(x => x.password).IsModified = false;
                            usu.Property(x => x.estado).IsModified = false;
                            db.SaveChanges();
                            ViewBag.ActualizacionOK = true;
                        }
                        break;

                    case "password":

                        var objeUsu = db.Usuarios.FirstOrDefault(x => x.id == ID);

                        //&& passrep == usuario.password
                        if (objeUsu.password == passant && passnue == passrep)
                        {
                            var usuarioEdit = db.Usuarios.Find(ID);
                            usuarioEdit.password = passnue;
                            db.Usuarios.Attach(usuarioEdit);
                            db.Entry(usuarioEdit).Property(x => x.password).IsModified = true;
                            db.SaveChanges();
                            ViewBag.ActualizacionOK = true;
                        }
                        break;
                }
                
                return Perfil(usuario.id);
            }
            catch
            {
                ViewBag.Error = true;
                return Perfil(usuario.id);
            }
        }


        [HttpPost]
        public JsonResult validarPasswordPorId(int id = 0, string passant = "")
        {
            var usuarioPass = db.Usuarios.Find(id);
            if (usuarioPass.password == passant)
            {
                bool passExiste = true;
                return Json(passExiste);
            }else
            {
                bool passExiste = false;
                return Json(passExiste);
            }
        }

        [HttpPost]
        public JsonResult validarEmailPorId(int id = 0, string email = "")
        {
            var usuarioPass = db.Usuarios.Find(id);
            if (usuarioPass.email == email)
            {
                bool passExiste = true;
                return Json(passExiste);
            }
            else
            {
                bool passExiste = false;
                return Json(passExiste);
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
