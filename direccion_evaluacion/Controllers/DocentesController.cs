using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using direccion_evaluacion.Models;
using System.Data.Entity;

namespace direccion_evaluacion.Controllers
{
    public class DocentesController : Controller
    {
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Docentes
        public ActionResult Index(string mensaje = "")
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    ViewBag.AccionOk = mensaje;

                    //consulta de usuarios con perfil de coordinador
                    var usuariosList = from Usuario in db.Usuarios
                                       where Usuario.Perfil.nombre == "Docente"
                                       select Usuario;
                    var docenteModList = from ModuloDocente in db.ModuloDocentes
                                         select ModuloDocente;

                    Modelos modelos = new Modelos();
                    modelos.ObjUsuario = usuariosList;
                    modelos.ObjModuloD = docenteModList;

                    return View(modelos);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }


        }

        // GET: Docentes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Docentes/Create
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

        // POST: Docentes/Create
        [HttpPost]
        public ActionResult Create(string nombre = "",
            string apellido = "", string cedula = "", string email = "",
            string telefono = "", string direccion = "", string password = "",
            int estado = 0)
        {
            //se busca el objeto perfil que va a utilizarce como clave foranea
            var perfilUsu = db.Perfiles.SingleOrDefault(x => x.nombre == "Docente");

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

                string mensaje = "Registro guardado exitosamente. !";

                return Redirect("/Docentes/Index?mensaje=" + mensaje);
            }
            catch
            {
                return View();
            }
        }

        // GET: Docentes/Edit/5
        public ActionResult Editar(int id)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() == "Coordinador")
                {
                    var usu = db.Usuarios.Find(id);
                    return View(usu);
                }
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

        // POST: Docentes/Edit/5
        [HttpPost]
        public ActionResult Editar([Bind(Include = "id,nombre,apellido,cedula,email,telefono,direccion,password,estado")]
                                    Usuario usuario, string estadoUsu = "", int ID = 0)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var usu = db.Entry(usuario);
                    usu.State = EntityState.Modified;
                    db.SaveChanges();

                    //modificar estado
                    var usuEstado = db.Usuarios.Find(usuario.id);
                    if (estadoUsu == "on")
                        usuEstado.estado = 1;
                    else
                        usuEstado.estado = 0;
                    db.Usuarios.Attach(usuEstado);
                    db.Entry(usuEstado).Property(x => x.estado).IsModified = true;
                    db.SaveChanges();
                }

                string mensaje = "Registro actualizado exitosamente. !";

                return Redirect("/Docentes/Index?mensaje=" + mensaje);
            }
            catch
            {
                return View();
            }
        }

        // GET: Docentes/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }
        */

        // POST: Docentes/Delete/5
        //[HttpPost]
        public RedirectResult Delete(int id = 0)
        {
            try
            {
                ModuloDocente md = db.ModuloDocentes.FirstOrDefault(x => x.Docente.id == id);
                if (md != null)
                {
                    db.ModuloDocentes.Remove(md);
                    db.SaveChanges();
                }

                Usuario usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();

                string mensaje = "Registro eliminado exitosamente. !";
                return Redirect("/Docentes/Index?mensaje=" + mensaje);
            }
            catch
            {
                string mensaje = "El registro no se elimino. !";
                return Redirect("/Docentes/Index?mensaje=" + mensaje);
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

        [HttpPost]
        public JsonResult validarEmailPorId(int id = 0, string email = "")
        {
            var usuarioId = db.Usuarios.Find(id);
            var usuarioEmail = db.Usuarios.SingleOrDefault(x => x.email == email);
            if (usuarioEmail == null || usuarioId.email == email)
            {
                bool existe = true;
                return Json(existe);
            }
            else
            {
                bool existe = false;
                return Json(existe);
            }
        }

        //mostrar coordinadores a los que se les envia las fichas asignadas
        public ActionResult Coordinadores(string mensaje = "")
        {
            if(Session["usuario"] != null && Session["usuario"].ToString() == "Docente" )
            {
                ViewBag.AccionOk = mensaje;

                //consulta de usuarios con perfil de coordinador
                var usuariosList = from Usuario in db.Usuarios
                                   where Usuario.Perfil.nombre == "Coordinador"
                                   select Usuario;
                var mdList = from ModuloDocente in db.ModuloDocentes
                                   select ModuloDocente;
                var moduloList = from Modulo in db.Modulos
                                   select Modulo;
                var fichaList = from Ficha in db.Fichas
                                   select Ficha;

                Modelos modelos = new Modelos();
                modelos.ObjUsuario = usuariosList;
                modelos.ObjModuloD = mdList;
                modelos.ObjModulo = moduloList;
                modelos.ObjFicha = fichaList;


                return View(modelos);
            }
            else
            {
                return Redirect("/Home");
            }
            
        }

    }
}
