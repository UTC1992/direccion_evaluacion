using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using direccion_evaluacion.Models;

namespace direccion_evaluacion.Controllers
{
    public class LoginController : Controller
    {
        //instanciacion de la base de datos 
        private EvaluacionDBContext db = new EvaluacionDBContext();

        /// <summary>
        /// verificacion de los datos ingresados en el formulario del login
        /// </summary>
        /// <param name="email_use"></param>
        /// <param name="password_use"></param>
        /// <returns>la vista con la session iniciada</returns>
        public ActionResult validarIdentificacion(string email_use, string password_use)
        {
            //consulta del usuario y contrasenia
            var usuarioQuery = from Usuario in db.Usuarios
                               where Usuario.email == email_use && Usuario.password == password_use
                               select Usuario;

            //variables
            string emailLogin = "";
            string passLogin = "";

            //recorriendo la variable de la consulta
            foreach (var result in usuarioQuery)
            {
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
                return Redirect("/Home/Login?dato=1");
            }

        }


       
    }
}
