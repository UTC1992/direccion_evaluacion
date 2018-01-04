using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace direccion_evaluacion.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index(string email = "", string usuario = "")
        {
            ViewBag.email = Session["email"];
            ViewBag.usuario = Session["usuario"];
            ViewBag.nombre = Session["nombre"];
            ViewBag.apellido = Session["apellido"];
            ViewBag.Id = Session["Id"];
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login(string dato = null)
        {
            ViewBag.Mostrar = dato;
            return View();
        }
    }
}