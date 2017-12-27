using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using direccion_evaluacion.Models;
using System.Web.Security;
using direccion_evaluacion.Helper;

namespace direccion_evaluacion.Controllers
{
    public class LoginController : Controller
    {
        //instanciacion de la base de datos 
        private EvaluacionDBContext db = new EvaluacionDBContext();

        // GET: Login
        public ActionResult Index()
        {
            if(Session["email"] != null)
            {
                return RedirectToAction("Index", "Home", new { email = Session["email"].ToString() });
            }
            else
            {
                return View();
            }
        }


        /// <summary>
        /// verificacion de los datos ingresados en el formulario del login
        /// </summary>
        /// <param name="email_use"></param>
        /// <param name="password_use"></param>
        /// <returns>la vista con la session iniciada</returns>
        [HttpPost]
        public ActionResult verificarIdentificacion(string email_use, string password_use)
         {

            var userLogin = db.Usuarios.SingleOrDefault(x => x.email == email_use && x.password == password_use);
            if(userLogin != null)
            {
                Session["email"] = email_use;

                return RedirectToAction("Index", "Home", new { email = email_use });
            }
            else
            {
                return Redirect("/Login/Index");
            }

            
            /*
            //consulta del usuario y contrasenia
            var usuarioQuery = from Usuario in db.Usuarios
                                where Usuario.email == email_use && Usuario.password == password_use
                                select Usuario;

            //variables
            string emailLogin = "";
            string passLogin = "";
            int id = 0;

             //recorriendo la variable de la consulta
             foreach (var result in usuarioQuery)
             {
                id = result.id;
                emailLogin = result.email;
                passLogin = result.password;
             }

             //comprobando la existencia de los datos ingresados en el formulario y redireccionando
             if (emailLogin.Length > 0 && passLogin.Length > 0)
             {
                

                return Redirect("/Home");
             }
             else
             {
                 //return Redirect("/Home/Login?dato=1");
                return Redirect("/Login/Index");
            }
            */

        }

        public ActionResult Salir()
        {
            if (Session["email"] != null)
            {
                Session.Remove("email");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
