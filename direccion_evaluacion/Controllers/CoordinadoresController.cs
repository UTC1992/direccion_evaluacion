using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using direccion_evaluacion.Models;

namespace direccion_evaluacion.Controllers
{
    public class CoordinadoresController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Coordinadores
        public ActionResult Index(string mensaje = "")
        {

            ViewBag.AccionOk = mensaje;

            //consulta de usuarios con perfil de coordinador
            var usuariosList = from Usuario in db.Usuarios
                               where Usuario.Perfil.id == 2
                               select Usuario;

            return View(usuariosList.ToList());
        }

        // GET: Coordinadores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Coordinadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coordinadores/Create
        [HttpPost]
        public ActionResult Create(string nombre = "",
            string apellido = "", string cedula = "", string email = "",
            string telefono = "", string direccion = "", string password = "", 
            int estado = 0, int perfil = 0)
        {
            //se busca el objeto perfil que va a utilizarce como clave foranea
            var perfilUsu = db.Perfiles.SingleOrDefault(x => x.id == perfil);

            try
            {
                //instanciamos una variable de tipo Usuario
                var usuarioAdd = new Usuario();
                //rellenamos los atributos del objeto de tipo Usuario
                usuarioAdd.nombre = nombre;
                usuarioAdd.apellido = apellido;
                usuarioAdd.cedula = cedula;
                usuarioAdd.email = email;
                usuarioAdd.telefono = telefono;
                usuarioAdd.direccion = direccion;
                usuarioAdd.password = password;
                usuarioAdd.estado = estado;
                usuarioAdd.Perfil = perfilUsu;
                //añadimos el objeto Usuario mediante Add
                db.Usuarios.Add(usuarioAdd);
                //guardamos los cambios realizados 
                db.SaveChanges();

                string mensaje= "Registro guardado exitosamente. !";

                return Redirect("/Coordinadores/Index?mensaje="+mensaje);
            }
            catch
            {
                return View();
            }
        }

        // GET: Coordinadores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Coordinadores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Coordinadores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Coordinadores/Delete/5
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

        [HttpPost]
        public JsonResult validarEmail(string email = "")
        {
            var usuario = db.Usuarios.SingleOrDefault(x => x.email == email);
            if (usuario == null)
            {
                bool usuExiste = true;
                return Json(usuExiste);
            }
            else
            {
                bool usuExiste = false;
                return Json(usuExiste);
            }
        }

        [HttpPost]
        public JsonResult validarCedula(string cedula = "")
        {
            var usuario = db.Usuarios.SingleOrDefault(x => x.cedula == cedula);
            if (usuario == null)
            {
                bool usuExiste = true;
                return Json(usuExiste);
            }
            else
            {
                bool usuExiste = false;
                return Json(usuExiste);
            }
        }
    }
}
